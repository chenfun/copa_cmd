using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class SystemParameter
    {
        public int Id { get; set; }
        /// <summary>
        /// 參數簡稱
        /// </summary>
        public string ParameterNo { get; set; } = null!;
        /// <summary>
        /// 參數中文名
        /// </summary>
        public string ParameterName { get; set; } = null!;
        /// <summary>
        /// 參數值
        /// </summary>
        public string ParameterValue { get; set; } = null!;
    }
}
