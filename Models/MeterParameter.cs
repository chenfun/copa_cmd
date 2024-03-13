using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MeterParameter
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 電表編號
        /// </summary>
        public string? MeterNo { get; set; }
        /// <summary>
        /// Plc對應編號
        /// </summary>
        public string? PlcNo { get; set; }
        /// <summary>
        /// 參數編號
        /// </summary>
        public string? ParaNo { get; set; }
        /// <summary>
        /// 參數名稱
        /// </summary>
        public string? ParaName { get; set; }
        /// <summary>
        /// 參數資料對應欄位
        /// </summary>
        public string? ParaFieldName { get; set; }
        /// <summary>
        /// 資料類型
        /// </summary>
        public string? DataType { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// 符號
        /// </summary>
        public string? Sign { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 啟用
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
    }
}
