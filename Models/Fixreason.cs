using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 維修原因
    /// </summary>
    public partial class Fixreason
    {
        /// <summary>
        /// ID
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// 原因
        /// </summary>
        public string Message { get; set; } = null!;
        /// <summary>
        /// 是否提醒？預設0不提醒
        /// </summary>
        public sbyte? Alarm { get; set; }
        /// <summary>
        /// 隸屬部位
        /// </summary>
        public int FixreasonCategory1Id { get; set; }
        /// <summary>
        /// 造成主因
        /// </summary>
        public int? FixreasonCategory2Id { get; set; }
    }
}
