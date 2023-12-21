using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具基本資料
    /// </summary>
    public partial class Mold
    {
        public int Id { get; set; }
        /// <summary>
        /// 模具編號
        /// </summary>
        public string MoldNo { get; set; } = null!;
        /// <summary>
        /// 模具基本生產量
        /// </summary>
        public int? BaseCount { get; set; }
        /// <summary>
        /// 模具價格
        /// </summary>
        public int? MoldPrice { get; set; }
    }
}
