using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 成型機檢驗欄位
    /// </summary>
    public partial class DetectionStandardSheet
    {
        public long Id { get; set; }
        /// <summary>
        /// 檢驗標準id
        /// </summary>
        public int DetectionStandardId { get; set; }
        /// <summary>
        /// 項目
        /// </summary>
        public string DetectionItemName { get; set; } = null!;
        /// <summary>
        /// 上限參考值
        /// </summary>
        public string UpperLimit { get; set; } = null!;
        /// <summary>
        /// 下限參考值
        /// </summary>
        public string LowerLimit { get; set; } = null!;
    }
}
