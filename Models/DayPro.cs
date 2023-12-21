using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class DayPro
    {
        public string ProcessName { get; set; } = null!;
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineId { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime? Startdate { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? Enddate { get; set; }
        public int NgCnt { get; set; }
        public int OkCnt { get; set; }
        public long Total { get; set; }
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineName { get; set; }
        /// <summary>
        /// 產品代號
        /// </summary>
        public string? ProductId { get; set; }
        /// <summary>
        /// 工單
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 產速
        /// </summary>
        public string? ProduceSpeed { get; set; }
        /// <summary>
        /// 產品料號
        /// </summary>
        public string? ProductNo { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Fullname { get; set; }
    }
}
