using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 模具使用紀錄
    /// </summary>
    public partial class MoldUseLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 模具代碼id
        /// </summary>
        public int MoldCategoryId { get; set; }
        /// <summary>
        /// 模具編號id
        /// </summary>
        public int MoldId { get; set; }
        /// <summary>
        /// 使用時工令
        /// </summary>
        public string WcNo { get; set; } = null!;
        /// <summary>
        /// 起始時間
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 起始時計數值
        /// </summary>
        public int StartCount { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 結束時計數值
        /// </summary>
        public int EndCount { get; set; }
        /// <summary>
        /// 模具更換紀錄id
        /// </summary>
        public int? MoldReplaceRecordId { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = null!;
        /// <summary>
        /// 統計分組 第一筆資料的id
        /// </summary>
        public int TotalGroupId { get; set; }
    }
}
