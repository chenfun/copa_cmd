using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class Language
    {
        public int Sid { get; set; }
        /// <summary>
        /// 正體中文
        /// </summary>
        public string Tw { get; set; } = null!;
        /// <summary>
        /// 簡體中文
        /// </summary>
        public string Cn { get; set; } = null!;
        /// <summary>
        /// 英文
        /// </summary>
        public string En { get; set; } = null!;
        /// <summary>
        /// 泰國
        /// </summary>
        public string Th { get; set; } = null!;
        /// <summary>
        /// 馬來西亞
        /// </summary>
        public string My { get; set; } = null!;
        /// <summary>
        /// 印尼
        /// </summary>
        public string Id { get; set; } = null!;
    }
}
