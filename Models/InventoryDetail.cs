using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class InventoryDetail
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 產品料號
        /// </summary>
        public string? ProductNo { get; set; }
        /// <summary>
        /// 調整數量
        /// </summary>
        public int? AdjustQty { get; set; }
        /// <summary>
        /// 包裝編號
        /// </summary>
        public string? PackagingNo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 建立者序號
        /// </summary>
        public int? CreaterId { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        public string? Creater { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
