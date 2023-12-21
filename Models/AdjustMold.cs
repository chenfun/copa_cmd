using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 機台尺寸調整紀錄表
    /// </summary>
    public partial class AdjustMold
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 模具大類id
        /// </summary>
        public int MoldCategoryId { get; set; }
        /// <summary>
        /// 模具編號id
        /// </summary>
        public int MoldId { get; set; }
        /// <summary>
        /// 機台id
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 操作員id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 調整開始時間
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 調整結束時間
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public sbyte Isok { get; set; }
        /// <summary>
        /// 開始時計數器計數
        /// </summary>
        public int? StartCount { get; set; }
        /// <summary>
        /// 結束時計數器計數
        /// </summary>
        public int? EndCount { get; set; }
    }
}
