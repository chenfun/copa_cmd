using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MeterDayRecord
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 電表編號
        /// </summary>
        public string? MeterNo { get; set; }
        /// <summary>
        /// 機台列表編號
        /// </summary>
        public string? MachineList { get; set; }
        /// <summary>
        /// 用電日期
        /// </summary>
        public string? MeasureDay { get; set; }
        /// <summary>
        /// 開始度數
        /// </summary>
        public string? StartDeg { get; set; }
        /// <summary>
        /// 結束度數
        /// </summary>
        public string? EndDeg { get; set; }
        /// <summary>
        /// 用電度數
        /// </summary>
        public string? TotalDeg { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
    }
}
