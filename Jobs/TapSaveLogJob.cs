using CopaCmd.Adc.Models;
using CopaCmd.Extensions;
using CopaCmd.Models;
using CopaCmd.ViewModel.Config;
using CopaCmd.ViewModel.Machine;
using CopaContext;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using Quartz;
using Serilog;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 更新攻牙機計數器資料
    /// </summary>
    [DisallowConcurrentExecution]
    public class TapSaveLogJob : IJob
    {
        private copapmsContext db = null;
        private CopaAdcContext dbAdc = null;
        private List<MachineTableTap> machines = new List<MachineTableTap>();
        private string logid = string.Empty;
        private DateTime logCreateTime;
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_取得計數器資料=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info  != null) paras = Helpers.JobHelper.ConvertParas(info.Paras);

                db = new copapmsContext();
                dbAdc = new CopaAdcContext();
                //取得更新前機台資料
                machines = db.MachineTableTaps.ToList();

                //限定某些機台取值
                bool isLimit = false;
                List<string> keys = new List<string>();
                if (isLimit) keys = new List<string> { "ojr7", "8noo", "20gu", "8lug", "iu5l", "3nsa" };

                //取得攻牙計數器資料
                List<MachineCounter> machineCounters = new List<MachineCounter>();
                machineCounters = await GetMachinesCounter();
                if (keys.Count > 0) machineCounters = machineCounters.Where(w => keys.Contains(w.PlcKey)).ToList();

                //處理計數器的資料
                foreach (var mc in machineCounters)
                {
                    var machine = machines.FirstOrDefault(w => w.PlcKey == mc.PlcKey);
                    if (machine  == null)
                    {
                        Log.Warning($"PLC Key {mc.PlcKey} 不存在於機器列表中");
                        continue;
                    }
                    int machineCount = string.IsNullOrWhiteSpace(machine.LastCnt) ? 0 : int.Parse(machine.LastCnt);
                    mc.MachineId = machine.MachineId;
                    mc.MachineName = machine.MachineName;
                    mc.WcId = machine.WorkingWc;
                    mc.WcdId = machine.WorkingWcdid.ToString();
                    mc.NowPlcCount = machine.PlcCnt;
                    //PLC重新計數
                    if (mc.isReset)
                    {
                        //若是PLC重新計算，則加入新抓的計數值
                        mc.MachineCount = machineCount + mc.NewPlcCount.Value;
                    }
                    else
                    {
                        mc.MachineCount = machineCount + mc.DiffCount;
                    }

                    //更新機台最新計數
                    machine.PlcCnt = mc.NewPlcCount;
                    machine.LastCnt = mc.MachineCount.ToString();
                    machine.LastUpdateTime = DateTime.Now;

                    //抓取ncode的值
                    if (machine.WorkingWcdid.HasValue)
                    {
                        //nocde數值有三個，空白、維修、換規格
                        var detail = db.WorkcommandDetailsTaps.FirstOrDefault(w => w.Id == machine.WorkingWcdid);
                        if (detail !=null)
                        {
                            mc.Ncode = detail.Ncode;
                            mc.Detail = detail;
                        }
                    }
                }

                //新增計數記錄，將收到的資料記錄到資料庫，只記錄MachineName跟Counter
                var saveData = machineCounters.Select(s => new MachineCounterLog { PlcKey = s.PlcKey, Name = s.MachineName, PlcCount = s.NewPlcCount.ToString(), MachineCount = s.MachineCount.ToString() }).ToList();
                var json = JsonConvert.SerializeObject(saveData);

                //await Console.Out.WriteLineAsync(json);

                //儲存記錄，並把記錄logid與建檔時間
                SavePlcLog(json);

                //分割時段
                CutShift(machineCounters);

                //機台狀態，取得每一機台最後的狀態
                var machineStatus = GetMachineLastStatus();

                //檢查更新機台狀態
                CheckMachineState(machineCounters, machineStatus);

                //重新取得更新後機台狀態資料
                var newMachineStatus = GetMachineLastStatus();

                //更新工令與工令細項
                UpdateWorkCommand(machineCounters, newMachineStatus);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新攻牙機計數器資料==>發生錯誤!!");
            }
            Log.Information("=====END_取得計數器資料=====");
        }

        public void SavePlcLog(string json)
        {
            Adc.Models.VigorplclogTap data = new Adc.Models.VigorplclogTap()
            {
                Category = "tap.value",
                JsonData = json,
                Desc = "攻牙計數"
            };
            dbAdc.VigorplclogTaps.Add(data);
            dbAdc.SaveChanges();
            logCreateTime = data.CreateTime.Value;
            logid = data.Id.ToString();
            Log.Information("寫入記錄LOG，Id==>{0}", logid);
        }

        /// <summary>
        /// 分割班別
        /// </summary>
        public void CutShift(List<MachineCounter> machineCounters)
        {
            foreach (var mc in machineCounters)
            {
                //若無此機台則跳過
                if (string.IsNullOrWhiteSpace(mc.MachineId)) continue;

                //分割班別，判斷是早班還是晚班，還是昨日班
                //明細開始時間與結束時間
                DateTime? detailStartTime = mc.Detail == null ? null : mc.Detail.Startdate;
                //目前時間
                DateTime nowWorkTime = DateTime.Now;
                //今天早班
                DateTime dayWorkTime = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 08:00:00");
                //今天晚班
                DateTime nightWorkTime = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 17:00:00");
                int hourInAdvance = -1;//提前1小時

                string nowShift = string.Empty;
                string workShift = "其他";
                //提前1個小時判斷是否為早班，故早班時間目前為07-17
                if (nightWorkTime.AddDays(-1) <= nowWorkTime && nowWorkTime < dayWorkTime.AddHours(hourInAdvance)) nowShift = "昨晚";
                if (dayWorkTime.AddHours(hourInAdvance) <= nowWorkTime && nowWorkTime < nightWorkTime) nowShift = "今早";
                if (nightWorkTime <= nowWorkTime) nowShift = "今晚";

                if (detailStartTime.HasValue)
                {
                    if (nightWorkTime.AddDays(-1) <= detailStartTime.Value && detailStartTime.Value < dayWorkTime.AddHours(hourInAdvance)) workShift = "昨晚";
                    if (dayWorkTime.AddHours(hourInAdvance) <= detailStartTime.Value && detailStartTime.Value < nightWorkTime) workShift = "今早";
                    if (nightWorkTime <= detailStartTime.Value) workShift = "今晚";
                }
                //若有派工單才進行寫入detail的檢查
                if (!string.IsNullOrWhiteSpace(mc.WcId))
                {
                    //若目前班別與工作班別不同，則新增一筆detail
                    if (nowShift != workShift)
                    {
                        //設定新的時間
                        DateTime newStartTime = DateTime.Now;
                        if (nowShift =="昨晚") newStartTime = nightWorkTime.AddDays(-1);
                        if (nowShift == "今早") newStartTime = dayWorkTime;
                        if (nowShift == "今晚") newStartTime = nightWorkTime;

                        WorkcommandDetailsTap newDetail = new WorkcommandDetailsTap();
                        newDetail.Startdate= newStartTime;
                        newDetail.WorkcommandId = mc.WcId;
                        newDetail.MachineId = mc.MachineId;
                        newDetail.Eid1 = mc.Detail.Eid1;
                        newDetail.StartCnt = mc.MachineCount;
                        newDetail.EndCnt = mc.MachineCount;
                        newDetail.OkCnt = newDetail.EndCnt - newDetail.StartCnt;
                        newDetail.Ncode = mc.Ncode; //延續未價動原因
                        newDetail.Perno ="";
                        newDetail.Status = "";
                        newDetail.PlineId = "";

                        db.WorkcommandDetailsTaps.Add(newDetail);
                        //結束明細資料
                        mc.Detail.Isok = 1;
                        //
                        if (workShift == "其他")
                        {
                            //中間電腦掛點遺失資料，EndCnt與OkCnt維持先前記錄
                            mc.Detail.Enddate = Utils.CopaUtil.GetWorkDetailEndDate(mc.Detail.Startdate.Value);
                        }
                        else
                        {
                            mc.Detail.Enddate = newDetail.Startdate;
                            mc.Detail.EndCnt = newDetail.StartCnt;
                            mc.Detail.OkCnt = mc.Detail.EndCnt - mc.Detail.StartCnt;
                        }
                        db.SaveChanges();
                        //有新增Detail，所以更新WcdId，但未更新至machine資料表
                        mc.WcdId = newDetail.Id.ToString();
                    }
                }
            }
        }

        public void CheckMachineState(List<MachineCounter> machineCounters, List<MachineStatusLogTap> machineStatus)
        {
            //找出前N秒記錄，因為是目前是設定抓前1分鐘
            int beforeSec = -63;
            var logData = dbAdc.VigorplclogTaps.OrderBy(o => o.Id).FirstOrDefault(w => w.CreateTime >= logCreateTime.AddSeconds(beforeSec));
            bool isSameLog = false;
            //判斷logData是否跟新增的logId相同
            if (logData.Id.ToString() == logid) isSameLog = true;
            List<MachineCounterLog> logs = new List<MachineCounterLog>();
            if (logData != null) logs = JsonConvert.DeserializeObject<List<MachineCounterLog>>(logData.JsonData);

            foreach (var mc in machineCounters)
            {
                //若無此機台則跳過
                if (string.IsNullOrWhiteSpace(mc.MachineId)) continue;

                string newStatus = string.Empty;
                string nowStatus = string.Empty;
                string note = string.Empty;

                var nowMachineStatus = machineStatus.FirstOrDefault(w => w.MachineId.Equals(int.Parse(mc.MachineId)));
                if (nowMachineStatus != null) nowStatus = nowMachineStatus.Status;

                //每分鐘rpm限制，若小於設定值的話，才判斷為閒置
                int rpm_limit = Helpers.JobHelper.GetPara<int>(paras, "rpm_limit", 5);
                int preMachineCount = 0;
                if (logs.Count > 0)
                {
                    preMachineCount = int.Parse(logs.First(w => w.PlcKey.Equals(mc.PlcKey)).MachineCount);
                }

                //判斷機台新的狀態，由計數器的差值知道現在是否是閒置或生產
                if (mc.DiffCount > 0)
                {
                    if (mc.DiffCount > rpm_limit)
                    {
                        //若一次生產數量直接大於rpm
                        newStatus = "生產";
                        note = "計數判斷生產";
                    }
                    else
                    {
                        //小於rpm則檢查
                        //若是rpm大於設定值就是生產階段
                        if ((mc.MachineCount - preMachineCount) > rpm_limit)
                        {
                            newStatus = "生產";
                            note = "計數判斷生產";
                        }
                        else
                        {
                            newStatus = "閒置";
                            note = $"區段產量{mc.DiffCount}小於rpm {rpm_limit} 計數判斷閒置";
                        }
                    }
                }
                else
                {
                    newStatus = "閒置";
                    note = "計數判斷閒置";

                    //若是重新計數的話
                    if (mc.isReset)
                    {
                        if (mc.NewPlcCount > 0)
                        {
                            newStatus = "生產";
                            note = "重新計數判斷生產";
                        }
                        else
                        {
                            newStatus = "閒置";
                            note = "重新計數判斷閒置";
                        }
                    }
                }
                //plc只能知道是否運作中(計數器是否有變化) 生產/閒置
                //機台還有管理狀態 關機/生產/閒置/換規格/換模具/維修
                if (string.IsNullOrWhiteSpace(newStatus))
                {
                    //沒有新狀態
                }
                else if (newStatus =="生產")
                {
                    //生產
                    //管理狀態轉生產
                }
                else if (newStatus=="閒置")
                {
                    //閒置

                    //管理狀態 關機=>關機
                    //管理狀態 閒置/換規格/換模具/維修 => 依工單狀態
                    //管理狀態 生產=>閒置

                    if (nowStatus =="關機")
                    {
                        //維持之前狀態
                        newStatus = nowStatus;
                    }
                    else
                    {
                        //依工單狀態

                        // 閒置 換規格 換模具 維修
                        if (!string.IsNullOrWhiteSpace(mc.Ncode))
                        {
                            newStatus = mc.Ncode;
                            note = "計數判斷閒置 改為細項狀態";
                        }
                        else
                        {
                            //維持之前狀態
                            newStatus = nowStatus;
                        }
                        if (newStatus == "生產") newStatus = "閒置";
                    }
                }

                //狀態改變 記錄新狀態
                if (!string.IsNullOrWhiteSpace(newStatus) && newStatus != nowStatus)
                {
                    //更新機台狀態
                    Log.Information($"更新機台狀態{mc.MachineName}[{nowStatus}]==>[{newStatus}]");
                    //新增machine_status_log
                    Models.MachineStatusLogTap statusLogTap = new Models.MachineStatusLogTap()
                    {
                        MachineId = int.Parse(mc.MachineId),
                        PlcNumber = mc.NewPlcCount - mc.DiffCount,
                        WcId = mc.WcId,
                        WcdId = string.IsNullOrWhiteSpace(mc.WcdId) ? null : int.Parse(mc.WcdId),
                        Note = note,
                        Status = newStatus,
                        StartTime = DateTime.Now,
                        MachineCount = mc.MachineCount - mc.DiffCount,
                        VigorplclogId = int.Parse(logid)
                    };
                    db.MachineStatusLogTaps.Add(statusLogTap);
                }
            }
            //新增狀態與更新機台最新資料
            db.SaveChanges();
        }

        public void UpdateWorkCommand(List<MachineCounter> machineCounters, List<MachineStatusLogTap> machineStatus)
        {
            foreach (var mc in machineCounters)
            {
                //若無此機台則跳過
                if (string.IsNullOrWhiteSpace(mc.MachineId)) continue;

                WorkcommandTap wc = null;
                WorkcommandDetailsTap detail = null;

                //Step1 先更新明細資料
                if (!string.IsNullOrWhiteSpace(mc.WcdId))
                {
                    //更新 workcommand_details資料
                    if (mc.WcdId != mc.Detail.Id.ToString())
                    {
                        //若有換班記錄的話，則不需要再新增detail
                    }
                    else
                    {
                        //沒有換班記錄，延續舊的記錄
                        detail = mc.Detail;
                        //若新重計數的話，需要新增一筆新的detail，並結束上筆detail
                        //目前只在早上六點會發生，PLC六點會歸零
                        if (mc.isReset)
                        {
                            //結束上筆，只記錄時間
                            detail.Isok = 1;
                            detail.Enddate = DateTime.Now;

                            //新增一筆明細
                            WorkcommandDetailsTap newDetail = new WorkcommandDetailsTap();
                            newDetail.Startdate= mc.Detail.Enddate;
                            newDetail.WorkcommandId = mc.WcId;
                            newDetail.MachineId = mc.MachineId;
                            newDetail.Eid1 = detail.Eid1;
                            newDetail.StartCnt = mc.MachineCount; //重新計算的話從0開始
                            newDetail.EndCnt = mc.MachineCount; //寫入endCnt
                            newDetail.OkCnt = newDetail.EndCnt - newDetail.StartCnt;  //計算okCnt
                            newDetail.Ncode = mc.Ncode; //延續未價動原因
                            newDetail.Perno ="";
                            newDetail.Status = "";
                            newDetail.PlineId = "";
                            db.WorkcommandDetailsTaps.Add(newDetail);
                            db.SaveChanges();
                            mc.WcdId = newDetail.Id.ToString();
                        }
                        else
                        {
                            detail.EndCnt = mc.MachineCount;
                            detail.OkCnt = detail.EndCnt -  detail.StartCnt;
                            db.SaveChanges();
                        }
                    }
                }

                //Step2 更新派工單總量
                if (!string.IsNullOrWhiteSpace(mc.WcId))
                {
                    //更新 workcommand資料，加總明細的ok_cnt 與 ng_cnt
                    var wcid = uint.Parse(mc.WcId);
                    wc = db.WorkcommandTaps.FirstOrDefault(w => w.WorkcommandId == mc.WcId);
                    if (wc != null)
                    {
                        var ok_cnt = db.WorkcommandDetailsTaps.Where(w => w.WorkcommandId == mc.WcId).Sum(s => s.OkCnt);
                        var ng_cnt = db.WorkcommandDetailsTaps.Where(w => w.WorkcommandId == mc.WcId).Sum(s => s.NgCnt);
                        var total = ok_cnt + ng_cnt;
                        wc.Ok = ok_cnt;
                        wc.Ng = ng_cnt;
                        wc.Total = total;
                    }
                    db.SaveChanges();
                }

                //Step3 更新機台目前資料
                if (!string.IsNullOrWhiteSpace(mc.WcdId))
                {
                    if (mc.WcdId != mc.Detail.Id.ToString())
                    {
                        var ma = machines.FirstOrDefault(w => w.MachineId== mc.MachineId);
                        if (ma !=null) ma.WorkingWcdid = int.Parse(mc.WcdId);
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// 取得機台最後狀態
        /// </summary>
        /// <returns></returns>
        public List<MachineStatusLogTap> GetMachineLastStatus()
        {
            var ret = new List<MachineStatusLogTap>();

            foreach (var ma in machines)
            {
                var status = db.MachineStatusLogTaps.OrderByDescending(o => o.Id).FirstOrDefault(w => w.MachineId.Equals(int.Parse(ma.MachineId)));
                if (status != null) { ret.Add(status); }
            }
            return ret;
        }

        /// <summary>
        /// 取得機台計數器資訊
        /// </summary>
        /// <returns></returns>
        public async Task<List<MachineCounter>> GetMachinesCounter()
        {
            List<MachineCounter> results = new List<MachineCounter>();
            var sc = new Services.SensorService();
            var datas = await sc.GetSensorsValues();

            for (int i = 0; i < datas.data.Count; i++)
            {
                var data = datas.data.ElementAt(i);
                string plcKey = data.Value.id;
                //PLC機台狀態
                string counterStatus = data.Value.status.ToString();

                //連線正常才取值
                if (counterStatus == "1")
                {
                    results.Add(new MachineCounter
                    {
                        NewPlcCount = int.Parse(data.Value.values.Values.First().ToString()),
                        PlcKey = data.Value.id,
                        Status = counterStatus,
                        UpdateTime = data.Value.updateTime.ToDateTimeString(),
                    });
                }
                else
                {
                    Log.Warning($"PLC機台 {plcKey} 狀態異常，狀態值為==>{counterStatus}");
                }
            }
            return results;
        }
    }
}