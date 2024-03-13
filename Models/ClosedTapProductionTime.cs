using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class ClosedTapProductionTime
    {
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? WorkStartdate { get; set; }
        public DateTime? WorkEnddate { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime? ProductionStartdate { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? ProductionEnddate { get; set; }
        public decimal? ProductionTimeSec { get; set; }
        /// <summary>
        /// 機台狀態 關機 閒置 維修 生產
        /// </summary>
        public string? Status { get; set; }
        public int? DetailTotal { get; set; }
        public int? Total { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineName { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
    }
}
