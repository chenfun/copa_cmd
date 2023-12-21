using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 工單
    /// </summary>
    public partial class WorkOrder
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string WorkNo { get; set; } = null!;
        /// <summary>
        /// 合併製令編號
        /// </summary>
        public string WorkNoN { get; set; } = null!;
        public int SeqNo { get; set; }
        /// <summary>
        /// 訂單單號
        /// </summary>
        public string OrderNo { get; set; } = null!;
        /// <summary>
        /// 發包單號
        /// </summary>
        public string EmployerNo { get; set; } = null!;
        /// <summary>
        /// 確認日期
        /// </summary>
        public DateOnly? ConfirmDate { get; set; }
        /// <summary>
        /// 廠商名稱
        /// </summary>
        public string Vendor { get; set; } = null!;
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string Customer { get; set; } = null!;
        /// <summary>
        /// 客戶單號
        /// </summary>
        public string CustomerSheet { get; set; } = null!;
        /// <summary>
        /// 產品品號
        /// </summary>
        public string ProductId { get; set; } = null!;
        /// <summary>
        /// 規格
        /// </summary>
        public string Spec { get; set; } = null!;
        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// 材質
        /// </summary>
        public string Material { get; set; } = null!;
        /// <summary>
        /// 訂單數量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string OrderUnit { get; set; } = null!;
        /// <summary>
        /// 贈品量
        /// </summary>
        public int GiftQty { get; set; }
        /// <summary>
        /// 預計產量
        /// </summary>
        public int ExpectedQty { get; set; }
        /// <summary>
        /// 已生產量
        /// </summary>
        public int ProductionQty { get; set; }
        /// <summary>
        /// 預計完工
        /// </summary>
        public DateOnly? ExpectedDate { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = null!;
        public int DispatchQty { get; set; }
        /// <summary>
        /// 模具號碼
        /// </summary>
        public string MoldNo { get; set; } = null!;
        public string DelFlag { get; set; } = null!;
        /// <summary>
        /// 上傳時間
        /// </summary>
        public DateTime? Createtime { get; set; }
        /// <summary>
        /// 是否結案
        /// </summary>
        public bool IsClosed { get; set; }
    }
}
