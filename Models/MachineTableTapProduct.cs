using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MachineTableTapProduct
    {
        /// <summary>
        /// 序號
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 機台序號
        /// </summary>
        public int? MachineId { get; set; }
        /// <summary>
        /// 產品序號
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// 產品料號
        /// </summary>
        public string? ProductNo { get; set; }
    }
}
