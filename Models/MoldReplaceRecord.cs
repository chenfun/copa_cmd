using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具更換紀錄
    /// </summary>
    public partial class MoldReplaceRecord
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 更換時工令
        /// </summary>
        public string? WcNo { get; set; }
        /// <summary>
        /// 模具代碼id
        /// </summary>
        public int MoldCategoryId { get; set; }
        /// <summary>
        /// 模具編號
        /// </summary>
        public int MoldId { get; set; }
        /// <summary>
        /// 模具部位
        /// </summary>
        public int FixreasonCategory1Id { get; set; }
        /// <summary>
        /// 造成主因
        /// </summary>
        public int FixreasonCategory2Id { get; set; }
        /// <summary>
        /// 更換原因
        /// </summary>
        public int FixreasonId { get; set; }
        /// <summary>
        /// 更換時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更換人員
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 拍照1
        /// </summary>
        public string? Photo1 { get; set; }
        /// <summary>
        /// 拍照2
        /// </summary>
        public string? Photo2 { get; set; }
        /// <summary>
        /// 拍照3
        /// </summary>
        public string? Photo3 { get; set; }
        /// <summary>
        /// 備註 自主輸入
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 機台計數器計數值
        /// </summary>
        public int? MachineCount { get; set; }
        /// <summary>
        /// 模具價格
        /// </summary>
        public int? MoldPrice { get; set; }
    }
}
