using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class PackagingDetail
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        public uint PackagingId { get; set; }
        /// <summary>
        /// 包裝編號
        /// </summary>
        public string? PackagingNo { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 產品料號
        /// </summary>
        public string? ProductNo { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 箱號
        /// </summary>
        public string? BoxNumber { get; set; }
        /// <summary>
        /// 桶數(多數使用，分隔)
        /// </summary>
        public string? BucketNumbers { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }

        public virtual PackagingRecord Packaging { get; set; } = null!;
    }
}
