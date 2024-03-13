using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.ViewModel.Machine
{
    public class MachineCounter
    {
        /// <summary>
        /// 機台編號
        /// </summary>
        public string MachineId { get; set; }

        /// <summary>
        /// 機台名稱
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// PLC編號
        /// </summary>
        public string PlcKey { get; set; }

        /// <summary>
        /// 感測器狀態(0：感測器斷線、1：連線正常、2：警報異常)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 0：感測器斷線、1：連線正常、2：警報異常
        /// </summary>
        public string StatusDesc
        {
            get
            {
                switch (Status)
                {
                    case "0":
                        return "感測器斷線";

                    case "1":
                        return "連線正常";

                    case "2":
                        return "警報異常";

                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 計數器數值
        /// </summary>
        public int? NewPlcCount { get; set; }

        /// <summary>
        /// 目前機台計數值
        /// </summary>
        public int? NowPlcCount { get; set; }

        /// <summary>
        /// 取得差值
        /// </summary>
        public int DiffCount
        {
            get
            {
                var newCnt = !NewPlcCount.HasValue ? 0 : NewPlcCount.Value;
                var nowcnt = !NowPlcCount.HasValue ? 0 : NowPlcCount.Value;
                var diff = newCnt - nowcnt;
                return diff < 0 ? 0 : diff;
            }
        }

        /// <summary>
        /// 是否重新計算計數器
        /// </summary>
        public bool isReset
        {
            get
            {
                var newCnt = !NewPlcCount.HasValue ? 0 : NewPlcCount.Value;
                var nowcnt = !NowPlcCount.HasValue ? 0 : NowPlcCount.Value;
                var diff = newCnt - nowcnt;
                return diff < 0 ? true : false;
            }
        }

        /// <summary>
        /// 機台累積計數值
        /// </summary>
        public int MachineCount { get; set; }

        /// <summary>
        /// 製令編號
        /// </summary>
        public string WkNo { get; set; }

        /// <summary>
        /// 派工單編號
        /// </summary>
        public string WcId { get; set; }

        /// <summary>
        /// 派工單明細編號
        /// </summary>
        public string WcdId { get; set; }

        /// <summary>
        /// 明細資料執行代碼
        /// 有空白、維修、換規格
        /// </summary>
        public string Ncode { get; set; }

        /// <summary>
        /// 派工明細
        /// </summary>
        public Models.WorkcommandDetailsTap Detail { get; set; }
    }

    public class MachineCounterLog
    {
        /// <summary>
        /// PLC KEY
        /// </summary>
        public string PlcKey { get; set; }

        /// <summary>
        /// 機台名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 計數器數值
        /// </summary>
        public string PlcCount { get; set; }

        /// <summary>
        /// 機台累積計數值
        /// </summary>
        public string MachineCount { get; set; }
    }
}