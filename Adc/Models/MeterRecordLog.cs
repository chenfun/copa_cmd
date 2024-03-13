using System;
using System.Collections.Generic;

namespace CopaCmd.Adc.Models
{
    public partial class MeterRecordLog
    {
        /// <summary>
        /// 序號
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// 電表編號
        /// </summary>
        public string? MeterNo { get; set; }
        /// <summary>
        /// 機台列表編號
        /// </summary>
        public string? MachineList { get; set; }
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
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
