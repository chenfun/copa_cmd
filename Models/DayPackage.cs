using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class DayPackage
    {
        /// <summary>
        /// 包裝編號
        /// </summary>
        public string? WrNo { get; set; }
        public DateOnly? WrDd { get; set; }
        /// <summary>
        /// 桶數(多數使用，分隔)
        /// </summary>
        public string? Rem { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        public string? Usr { get; set; }
        public string Dep { get; set; } = null!;
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? MoNo { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? PrdNo { get; set; }
        public string QtyFin { get; set; } = null!;
        public string ZcNo { get; set; } = null!;
        /// <summary>
        /// 箱號
        /// </summary>
        public string? BatNo { get; set; }
    }
}
