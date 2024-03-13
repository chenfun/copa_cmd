using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class CopaWorkOrderPowerinfo
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineName { get; set; }
        /// <summary>
        /// 電表名稱
        /// </summary>
        public string? MeterName { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 產品品號
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 總生產秒數
        /// </summary>
        public int? TotalProductionSecs { get; set; }
        /// <summary>
        /// 總生產量
        /// </summary>
        public int? TotalCnt { get; set; }
        /// <summary>
        /// 明細總生產量
        /// </summary>
        public int? DetailTotalCnt { get; set; }
        /// <summary>
        /// 總秏電量
        /// </summary>
        public string? TotalPowerConsumption { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
