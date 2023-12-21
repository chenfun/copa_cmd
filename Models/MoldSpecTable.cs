using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 成型機模具編號表主項目
    /// </summary>
    public partial class MoldSpecTable
    {
        public int Id { get; set; }
        /// <summary>
        /// 表單編號
        /// </summary>
        public string FormNo { get; set; } = null!;
        /// <summary>
        /// 車型
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string ProductId { get; set; } = null!;
        /// <summary>
        /// 產速 每分鐘生產量
        /// </summary>
        public int? Rpm { get; set; }
        /// <summary>
        /// 標準生產效率
        /// </summary>
        public float BaseEff { get; set; }
        /// <summary>
        /// 印記jpg
        /// </summary>
        public string? PhotoSop { get; set; }
        /// <summary>
        /// 印記說明
        /// </summary>
        public string? PhotoNote { get; set; }
        /// <summary>
        /// 轉運說明
        /// </summary>
        public string Rotate { get; set; } = null!;
        /// <summary>
        /// 客戶主圖號
        /// </summary>
        public string? CustomerMoldId { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
