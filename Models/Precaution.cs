using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 注意事項
    /// </summary>
    public partial class Precaution
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 填寫人員工id
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        /// 填寫時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 下架時間
        /// </summary>
        public DateTime? DiscontinuedTime { get; set; }
        /// <summary>
        /// 針對機台 未設為所有機台
        /// </summary>
        public int? MachineId { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
    }
}
