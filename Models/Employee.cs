using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 員工
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Fullname { get; set; }
        /// <summary>
        /// 職務
        /// </summary>
        public string? Postition { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string? Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 程式權限
        /// </summary>
        public string Privilege { get; set; } = null!;
        /// <summary>
        /// 狀態
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// 登入令牌
        /// </summary>
        public string Token { get; set; } = null!;
    }
}
