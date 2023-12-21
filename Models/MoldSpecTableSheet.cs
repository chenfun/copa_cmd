using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 成型機模具編號對應
    /// </summary>
    public partial class MoldSpecTableSheet
    {
        public int Id { get; set; }
        /// <summary>
        /// 成型機模具編號表id
        /// </summary>
        public int MoldSpecTableId { get; set; }
        /// <summary>
        /// 模具大分類
        /// </summary>
        public string MoldCategoryId { get; set; } = null!;
        /// <summary>
        /// 模具小分類
        /// </summary>
        public string MoldId { get; set; } = null!;
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// Excel列號
        /// </summary>
        public string? ExcelRow { get; set; }
        /// <summary>
        /// 模具部位id
        /// </summary>
        public sbyte MoldPartId { get; set; }
    }
}
