using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class UserDevice
    {
        public int Id { get; set; }
        /// <summary>
        /// 機台編號
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// 裝置名稱
        /// </summary>
        public string DeviceName { get; set; } = null!;
        public string DeviceOs { get; set; } = null!;
        /// <summary>
        /// 裝置
        /// </summary>
        public string DeviceId { get; set; } = null!;
        /// <summary>
        /// APP推播識別ID
        /// </summary>
        public string AppId { get; set; } = null!;
        /// <summary>
        /// 是否send訊息
        /// </summary>
        public int Issend { get; set; }
        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
