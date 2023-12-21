using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MachinesCountLogBackup
    {
        public int Id { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 機台計數器計數值
        /// </summary>
        public int MachineCount { get; set; }
        /// <summary>
        /// plc計數值
        /// </summary>
        public int PlcCount { get; set; }
    }
}
