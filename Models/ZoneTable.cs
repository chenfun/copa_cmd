using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 區域
    /// </summary>
    public partial class ZoneTable
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 區域名稱
        /// </summary>
        public string ZoneName { get; set; } = null!;
        /// <summary>
        /// 區域代號
        /// </summary>
        public string ZoneNumber { get; set; } = null!;
        /// <summary>
        /// 可生產產品代號
        /// </summary>
        public string ProduceProduct { get; set; } = null!;
        /// <summary>
        /// 可生產最小內徑
        /// </summary>
        public string ProduceSpecInsideMin { get; set; } = null!;
        /// <summary>
        /// 可生產最大內徑
        /// </summary>
        public string ProduceSpecInsideMax { get; set; } = null!;
        /// <summary>
        /// 可生產最小外徑
        /// </summary>
        public string ProduceSpecOutsideMin { get; set; } = null!;
        /// <summary>
        /// 可生產最大外徑
        /// </summary>
        public string ProduceSpecOutsideMax { get; set; } = null!;
    }
}
