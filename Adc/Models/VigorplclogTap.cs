using System;
using System.Collections.Generic;

namespace CopaCmd.Adc.Models
{
    public partial class VigorplclogTap
    {
        public ulong Id { get; set; }
        public string? Category { get; set; }
        public string? Desc { get; set; }
        public string? JsonData { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
