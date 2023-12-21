using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具使用統計
    /// </summary>
    public partial class MoldUseTotal
    {
        public int Id { get; set; }
        /// <summary>
        /// 統計分組
        /// </summary>
        public int TotalGroupId { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 模具代碼id
        /// </summary>
        public int MoldCategoryId { get; set; }
        /// <summary>
        /// 模具編號id
        /// </summary>
        public int MoldId { get; set; }
        /// <summary>
        /// 起始時間
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 總使用時間 秒
        /// </summary>
        public int TotalUseTime { get; set; }
        /// <summary>
        /// 總使用計數
        /// </summary>
        public int TotalUseCount { get; set; }
        /// <summary>
        /// 模具更換紀錄id
        /// </summary>
        public int? MoldReplaceRecordId { get; set; }
    }
}
