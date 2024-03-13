using CopaContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Services
{
    public class MachineService
    {
        private string defaultAlertMsg = "機台 {0} 總生產秒數 [{1}] 已超過警示秒數 [{2}]，請盡快進行保養!";

        public MachineService()
        {
        }

        public async Task UpdateProduceTotalTime(Dictionary<string, string> paras = null)
        {
            var db = new copapmsContext();
            var machines = db.MachineTables.OrderBy(o => o.MachineOrder).ToList();
            //計算每台機器的生產秒數
            foreach (var ma in machines)
            {
                var lastId = ma.CalcLastStatusLogId;
                int total_sec = ma.ProduceTotalTime.HasValue ? ma.ProduceTotalTime.Value : 0;

                Log.Information("機台：{0} 開始更新生產總時間", ma.MachineName);
                List<Models.MachineStatusLog> datas;
                //若有last_log_id，則抓取這個id後的記錄即可
                if (lastId.HasValue)
                {
                    datas = db.MachineStatusLogs.Where(w => w.Id >= lastId.Value && w.MachineId == ma.Id).OrderBy(o => o.StartTime).ToList();
                }
                else
                {
                    datas = db.MachineStatusLogs.Where(w => w.MachineId == ma.Id).OrderBy(o => o.StartTime).ToList();
                }

                int sec = 0;
                //找出所有狀態是生產的
                var produceDatas = datas.Where(w => w.Status == "生產").ToList();

                if (produceDatas.Count > 0)
                {
                    foreach (var pd in produceDatas)
                    {
                        //找出下一筆的開始時間，等於本記錄生產的結束時間
                        var nextData = datas.FirstOrDefault(w => w.Id > pd.Id);
                        //若找不到下一筆，則表示即為最後一筆
                        if (nextData == null)
                        {
                            lastId = pd.Id;
                            break;
                        }
                        lastId = nextData.Id;
                        //計算生產時間
                        sec = Convert.ToInt32((nextData.StartTime - pd.StartTime).TotalSeconds);
                        total_sec += sec;
                    }
                    ma.CalcLastStatusLogId = lastId;
                    ma.ProduceTotalTime = total_sec;
                    await db.SaveChangesAsync();
                }
                Log.Information("機台：{0}，更新總生產數秒：{1}", ma.MachineName, total_sec);

                //若生產時間大於設定警示秒數
                if (ma.ProduceTotalTime > ma.AlertSec)
                {
                    if (ma.AlertEnabled == 1)
                    {
                        //檢查是否已有公告，若無則新增一筆公告內容
                        DateTime nowAlert = DateTime.Now;
                        var pt = db.Precautions.FirstOrDefault(w => w.MachineId == ma.Id
                        && w.Note =="生產保養警示"
                        && w.CreateTime.Value < nowAlert
                        && nowAlert < w.DiscontinuedTime.Value);

                        if (pt  == null)
                        {
                            //下架設定天數
                            int discontinued_day = Helpers.JobHelper.GetPara<int>(paras, "discontinued_day", 7);
                            DateTime discontinued_time = DateTime.Today.AddDays(discontinued_day); //預設下架天數
                            string alertMsg = "機台 " + ma.MachineName + " " + ma.AlertMsg;
                            if (string.IsNullOrWhiteSpace(ma.AlertMsg))
                            {
                                //使用預設警示訊息
                                alertMsg = string.Format(defaultAlertMsg, ma.MachineName, ma.ProduceTotalTime.ToString(), ma.AlertSec.ToString());
                            }
                            Models.Precaution pre = new Models.Precaution();
                            pre.MachineId = ma.Id;
                            pre.DiscontinuedTime = discontinued_time;
                            pre.Note = "生產保養警示";
                            pre.Content = alertMsg;
                            pre.Creator = 33; //預設為幼鵬
                            pre.CreateTime = DateTime.Today;
                            db.Precautions.Add(pre);
                            await db.SaveChangesAsync();
                            //新增一筆公告
                            Log.Information("機台：{0}，新增公告，生產秒數已超過警示設定秒數", ma.MachineName);
                        }
                    }
                }
            }
        }
    }
}