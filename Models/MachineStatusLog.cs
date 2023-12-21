using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 機台狀態歷史
    /// </summary>
    public partial class MachineStatusLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 機台狀態 關機 閒置 維修 生產
        /// </summary>
        public string Status { get; set; } = null!;
        /// <summary>
        /// 狀態起始時間
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 紀錄時工令
        /// </summary>
        public string? WcId { get; set; }
        /// <summary>
        /// 工令細項表id
        /// </summary>
        public int? WcdId { get; set; }
        /// <summary>
        /// plc計數值
        /// </summary>
        public int? PlcNumber { get; set; }
        /// <summary>
        /// 機台計數器計數值
        /// </summary>
        public int? MachineCount { get; set; }
        /// <summary>
        /// 計數紀錄id
        /// </summary>
        public int? VigorplclogId { get; set; }
        /// <summary>
        /// 註記
        /// </summary>
        public string Note { get; set; } = null!;
    }
}
