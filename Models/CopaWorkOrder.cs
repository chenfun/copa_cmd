using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 國鵬工單
    /// </summary>
    public partial class CopaWorkOrder
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// 合併製令編號
        /// </summary>
        public string? WorkNoN { get; set; }
        public sbyte? SeqNo { get; set; }
        /// <summary>
        /// 訂單單號
        /// </summary>
        public string OrderNo { get; set; } = null!;
        /// <summary>
        /// 客戶確認日期
        /// </summary>
        public DateTime? ConfirmDate { get; set; }
        /// <summary>
        /// 客戶
        /// </summary>
        public string Customer { get; set; } = null!;
        /// <summary>
        /// 客戶訂單編號
        /// </summary>
        public string CustomerSheet { get; set; } = null!;
        /// <summary>
        /// 產品品號
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 訂單數量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string? OrderUnit { get; set; }
        /// <summary>
        /// 預計產量
        /// </summary>
        public int? ExpectedQty { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 新增時間
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 是否結案
        /// </summary>
        public bool IsClosed { get; set; }
        /// <summary>
        /// 是否生產完成_攻牙製程選擇用
        /// </summary>
        public bool IsClosedTapping { get; set; }
        /// <summary>
        /// 生產完成時間
        /// </summary>
        public DateTime? TapClosedTime { get; set; }
        /// <summary>
        /// 完成者
        /// </summary>
        public string? TapClosedUser { get; set; }
        /// <summary>
        /// 結案時間
        /// </summary>
        public DateTime? ClosedTime { get; set; }
        /// <summary>
        /// 結案者
        /// </summary>
        public string? ClosedUser { get; set; }
        /// <summary>
        /// 交貨地點
        /// </summary>
        public string DeliveryPlace { get; set; } = null!;
        /// <summary>
        /// 交貨期限
        /// </summary>
        public DateOnly? DeliveryDate { get; set; }
        /// <summary>
        /// 包裝
        /// </summary>
        public string Packing { get; set; } = null!;
    }
}
