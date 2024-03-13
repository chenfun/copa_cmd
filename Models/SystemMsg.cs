using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class SystemMsg
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// 處理訊息
        /// </summary>
        public string? Msg { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
