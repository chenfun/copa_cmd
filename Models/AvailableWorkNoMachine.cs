using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class AvailableWorkNoMachine
    {
        /// <summary>
        /// 工令
        /// </summary>
        public string? WorkcommandId { get; set; }
        /// <summary>
        /// 序號
        /// </summary>
        public uint? WorkcommandDetailsId { get; set; }
        public int? Total { get; set; }
        /// <summary>
        /// 訂單數量
        /// </summary>
        public int? OrderQty { get; set; }
        /// <summary>
        /// 製令編號
        /// </summary>
        public string? WorkNo { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int? MachineId { get; set; }
        public int? ProductId { get; set; }
        /// <summary>
        /// 機台名稱
        /// </summary>
        public string? MachineName { get; set; }
        /// <summary>
        /// 規格
        /// </summary>
        public string? ProductName { get; set; }
    }
}
