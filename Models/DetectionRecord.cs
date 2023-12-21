using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 檢測紀錄
    /// </summary>
    public partial class DetectionRecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 檢測標準id
        /// </summary>
        public int DetectionStandardId { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
