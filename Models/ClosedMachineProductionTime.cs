using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class ClosedMachineProductionTime
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint WorkcommandId { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        /// <summary>
        /// 工單
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 產品代號
        /// </summary>
        public string? ProductId { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 機台代號
        /// </summary>
        public int? MachineId { get; set; }
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineName { get; set; }
        public int? Total { get; set; }
        public decimal? ProductionTimeSec { get; set; }
    }
}
