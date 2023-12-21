using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class DetectionRecordSheet
    {
        public int Id { get; set; }
        /// <summary>
        /// 檢測紀錄主項id
        /// </summary>
        public int DetectionRecordId { get; set; }
        /// <summary>
        /// 檢測標準細項id
        /// </summary>
        public int DetectionStandardSheetId { get; set; }
        /// <summary>
        /// 紀錄資料
        /// </summary>
        public string Value { get; set; } = null!;
    }
}
