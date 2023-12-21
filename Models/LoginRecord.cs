using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 登入紀錄
    /// </summary>
    public partial class LoginRecord
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
        /// 人員id
        /// </summary>
        public int EmployeesId { get; set; }
        /// <summary>
        /// 登入身份
        /// </summary>
        public string Position { get; set; } = null!;
        /// <summary>
        /// 上線時間
        /// </summary>
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 離線時間
        /// </summary>
        public DateTime? LogoutTime { get; set; }
        /// <summary>
        /// 任務報告
        /// </summary>
        public string Report { get; set; } = null!;
    }
}
