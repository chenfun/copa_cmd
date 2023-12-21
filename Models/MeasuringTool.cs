using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具代碼
    /// </summary>
    public partial class MeasuringTool
    {
        public int Id { get; set; }
        /// <summary>
        /// 量具編號
        /// </summary>
        public string MeasuringToolNo { get; set; } = null!;
    }
}
