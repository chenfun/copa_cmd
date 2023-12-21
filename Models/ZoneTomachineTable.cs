using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 區域對應機台
    /// </summary>
    public partial class ZoneTomachineTable
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 產線代號
        /// </summary>
        public uint? ZoneId { get; set; }
        /// <summary>
        /// 機台代號
        /// </summary>
        public string? MachineId { get; set; }
        public int MachineOrder { get; set; }
    }
}
