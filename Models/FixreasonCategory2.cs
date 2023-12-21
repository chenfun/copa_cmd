using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 維修原因隸屬部位
    /// </summary>
    public partial class FixreasonCategory2
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 隸屬部位
        /// </summary>
        public string CategoryName { get; set; } = null!;
    }
}
