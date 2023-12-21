using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 工令主檔
    /// </summary>
    public partial class Workcommand
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 工令
        /// </summary>
        public string WorkcommandId { get; set; } = null!;
        public int? SeqNo { get; set; }
        /// <summary>
        /// 工單
        /// </summary>
        public string? WorkNo { get; set; }
        public string? OrderNo { get; set; }
        /// <summary>
        /// 產品代號
        /// </summary>
        public string? ProductId { get; set; }
        /// <summary>
        /// 線別代號
        /// </summary>
        public string? PlineId { get; set; }
        /// <summary>
        /// ADC
        /// </summary>
        public uint? PlcId { get; set; }
        /// <summary>
        /// 機台代號
        /// </summary>
        public int? MachineId { get; set; }
        /// <summary>
        /// 派工量
        /// </summary>
        public int? PutIn { get; set; }
        /// <summary>
        /// 派工單位(1:雙 2:片 3:模)
        /// </summary>
        public string? Units { get; set; }
        public int? Ok { get; set; }
        public int? Ng { get; set; }
        public int? Total { get; set; }
        /// <summary>
        /// 模數
        /// </summary>
        public int? MoldCount { get; set; }
        public DateTime? Createtime { get; set; }
        /// <summary>
        /// 開工時間
        /// </summary>
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Mtime { get; set; }
        /// <summary>
        /// 0:未完成, 1:已完成, 2:取消
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string? Shift { get; set; }
        public string? MoldNo { get; set; }
        /// <summary>
        /// 0為量產單，1為打樣單
        /// </summary>
        public int? SampleReceipt { get; set; }
        /// <summary>
        /// 預計產量(M)
        /// </summary>
        public int? ExpectedQty { get; set; }
        /// <summary>
        /// 已生產量(M)
        /// </summary>
        public int? ProductionQty { get; set; }
        /// <summary>
        /// 預計開工
        /// </summary>
        public DateTime? ExpectedStartdate { get; set; }
        /// <summary>
        /// 預計完工
        /// </summary>
        public DateTime? ExpectedEnddate { get; set; }
        /// <summary>
        /// 產速
        /// </summary>
        public string? ProduceSpeed { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 計算過程
        /// </summary>
        public string? CalculateNote { get; set; }
    }
}
