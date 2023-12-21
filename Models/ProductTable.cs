using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    /// <summary>
    /// 產品資料表
    /// </summary>
    public partial class ProductTable
    {
        public int Id { get; set; }
        /// <summary>
        /// 產品料號
        /// </summary>
        public string ProductNo { get; set; } = null!;
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 尺寸規格
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// 材質
        /// </summary>
        public string? Material { get; set; }
        /// <summary>
        /// 線徑
        /// </summary>
        public string? Radius { get; set; }
        /// <summary>
        /// 棘輪
        /// </summary>
        public string? Ratchet { get; set; }
        /// <summary>
        /// 材料重
        /// </summary>
        public string? MaterialHeavy { get; set; }
        /// <summary>
        /// 牙級
        /// </summary>
        public string? ToothLevel { get; set; }
        /// <summary>
        /// 攻牙重
        /// </summary>
        public string? ToothHeavy { get; set; }
        /// <summary>
        /// 未攻牙重
        /// </summary>
        public string? NoToothHeavy { get; set; }
        /// <summary>
        /// 單位重
        /// </summary>
        public string? UnitHeavy { get; set; }
        /// <summary>
        /// 客戶
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// 客戶主圖號
        /// </summary>
        public string? ProductSop { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 委外攻牙
        /// </summary>
        public string? OutsourcingTapping { get; set; }
        /// <summary>
        /// 熱處理
        /// </summary>
        public string? HeatTreatment { get; set; }
        /// <summary>
        /// 壓尼龍圈
        /// </summary>
        public string? PressedNylonRing { get; set; }
        /// <summary>
        /// 委外生產
        /// </summary>
        public string? OutsourcingProduce { get; set; }
        /// <summary>
        /// 車型類型
        /// </summary>
        public string? MachineType { get; set; }
        /// <summary>
        /// 產品序號
        /// </summary>
        public string? ProductIso { get; set; }
        /// <summary>
        /// 即時庫存數(箱數)
        /// </summary>
        public int? StockQty { get; set; }
    }
}
