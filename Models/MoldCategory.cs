using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具代碼
    /// </summary>
    public partial class MoldCategory
    {
        public int Id { get; set; }
        /// <summary>
        /// 模具編號
        /// </summary>
        public string MoldCategoryNo { get; set; } = null!;
        /// <summary>
        /// 權重 越大排越前面 小於0隱藏
        /// </summary>
        public int Weight { get; set; }
    }
}
