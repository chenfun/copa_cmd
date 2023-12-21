using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class PackagingRecord
    {
        public PackagingRecord()
        {
            PackagingDetails = new HashSet<PackagingDetail>();
        }

        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 包裝編號
        /// </summary>
        public string? PackagingNo { get; set; }
        /// <summary>
        /// 箱數
        /// </summary>
        public int? BoxCnt { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 狀態  0-已入庫、1-已入ERP、2-已刪除
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// 更新者序號
        /// </summary>
        public int? UpdaterId { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public string? Updater { get; set; }
        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdateTime { get; set; }
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

        public virtual ICollection<PackagingDetail> PackagingDetails { get; set; }
    }
}
