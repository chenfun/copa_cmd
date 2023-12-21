using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MachineTableTap
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 機台連結的plc名稱
        /// </summary>
        public string PlcKey { get; set; } = null!;
        /// <summary>
        /// 機台代號
        /// </summary>
        public string MachineId { get; set; } = null!;
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string MachineName { get; set; } = null!;
        /// <summary>
        /// 單位
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// 製造廠商
        /// </summary>
        public string? Manufactor { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? Spec { get; set; }
        /// <summary>
        /// 入廠時間
        /// </summary>
        public DateOnly? Buyintime { get; set; }
        /// <summary>
        /// 維修時間
        /// </summary>
        public DateOnly? Fixtime { get; set; }
        /// <summary>
        /// 維護者
        /// </summary>
        public string? Maintainer { get; set; }
        /// <summary>
        /// 最後計數更新時間
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
        /// <summary>
        /// 最後計數數字
        /// </summary>
        public string? LastCnt { get; set; }
        /// <summary>
        /// plc計數值
        /// </summary>
        public int? PlcCnt { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// 最後執行的工令
        /// </summary>
        public string? WorkingWc { get; set; }
        /// <summary>
        /// 正在執行workcommand_details_id
        /// </summary>
        public int? WorkingWcdid { get; set; }
        /// <summary>
        /// 機台狀態
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否啟用預警通知
        /// </summary>
        public bool? AlertEnabled { get; set; }
        /// <summary>
        /// 保養預警秒數
        /// </summary>
        public int? AlertSec { get; set; }
        /// <summary>
        /// 預警通知訊息
        /// </summary>
        public string? AlertMsg { get; set; }
        /// <summary>
        /// 清除警示時間
        /// </summary>
        public DateTime? AlertClearTime { get; set; }
        /// <summary>
        /// 清除警示之使用者
        /// </summary>
        public string? AlertClearUser { get; set; }
        /// <summary>
        /// 清除生產時間最後編號
        /// </summary>
        public int? LastStatusLogId { get; set; }
        /// <summary>
        /// 計算生產時間最後編號
        /// </summary>
        public int? CalcLastStatusLogId { get; set; }
        /// <summary>
        /// 生產總時間(秒)
        /// </summary>
        public int? ProduceTotalTime { get; set; }
        /// <summary>
        /// 機台排列順序
        /// </summary>
        public int? MachineOrder { get; set; }
        /// <summary>
        /// 機台關機開始
        /// </summary>
        public DateTime? OffTimeStart { get; set; }
        /// <summary>
        /// 機台關機結束
        /// </summary>
        public DateTime? OffTimeEnd { get; set; }
        /// <summary>
        /// 機台類別
        /// </summary>
        public string? Machinetype { get; set; }
    }
}
