using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 交接事項
    /// </summary>
    public partial class Handover
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 車型id
        /// </summary>
        public string MachineId { get; set; } = null!;
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
        /// 看過與否。0未看，1看過
        /// </summary>
        public sbyte? Read { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
    }
}
