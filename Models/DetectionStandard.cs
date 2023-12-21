using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 成型機檢驗標準對應表
    /// </summary>
    public partial class DetectionStandard
    {
        public int Id { get; set; }
        /// <summary>
        /// 車型
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 量具id
        /// </summary>
        public int? MeasuringToolId { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
