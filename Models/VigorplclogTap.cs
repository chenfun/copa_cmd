using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class VigorplclogTap
    {
        public int Id { get; set; }
        /// <summary>
        /// PLC名稱
        /// </summary>
        public string PlcName { get; set; } = null!;
        /// <summary>
        /// PLC資料
        /// </summary>
        public string? JsonData { get; set; }
        /// <summary>
        /// 新增時間
        /// </summary>
        public DateTime? Createtime { get; set; }
    }
}
