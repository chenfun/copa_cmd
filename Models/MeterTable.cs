using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MeterTable
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
        /// 電表名稱
        /// </summary>
        public string? MeterName { get; set; }
        /// <summary>
        /// plc代碼
        /// </summary>
        public string? PlcName { get; set; }
        /// <summary>
        /// 用電機台列表
        /// </summary>
        public string? MachineList { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public sbyte? Sort { get; set; }
        /// <summary>
        /// 平均電壓
        /// </summary>
        public string? AvgVoltage { get; set; }
        /// <summary>
        /// 平均電流
        /// </summary>
        public string? AvgCurrent { get; set; }
        /// <summary>
        /// 功率因數
        /// </summary>
        public string? PowerFactor { get; set; }
        /// <summary>
        /// 頻率
        /// </summary>
        public string? Frequency { get; set; }
        /// <summary>
        /// 秏電量
        /// </summary>
        public string? Electricity { get; set; }
        /// <summary>
        /// 累積用電量
        /// </summary>
        public string? CumulativePower { get; set; }
        /// <summary>
        /// 日累積用電
        /// </summary>
        public string? DailyAccumulatedElectricity { get; set; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string? Status { get; set; }
    }
}
