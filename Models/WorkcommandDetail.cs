using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 工令明細檔
    /// </summary>
    public partial class WorkcommandDetail
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 工令
        /// </summary>
        public string WorkcommandId { get; set; } = null!;
        public int SeqNo { get; set; }
        /// <summary>
        /// 線別
        /// </summary>
        public string PlineId { get; set; } = null!;
        /// <summary>
        /// 機台
        /// </summary>
        public string MachineId { get; set; } = null!;
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime? Startdate { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? Enddate { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; } = null!;
        /// <summary>
        /// 未稼動
        /// </summary>
        public string Ncode { get; set; } = null!;
        /// <summary>
        /// 員工
        /// </summary>
        public string Perno { get; set; } = null!;
        public int Isok { get; set; }
        /// <summary>
        /// 操作員帳號
        /// </summary>
        public string Eid1 { get; set; } = null!;
        public string? Eid2 { get; set; }
        public string? Shift1 { get; set; }
        public string? Shift2 { get; set; }
        public int StartCnt { get; set; }
        /// <summary>
        /// 生產總數量
        /// </summary>
        public int EndCnt { get; set; }
        public int StartNgCnt { get; set; }
        public int EndNgCnt { get; set; }
        public int NgCnt { get; set; }
        public int OkCnt { get; set; }
        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
