using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class ErpDataEmuSecond
    {
        public int Id { get; set; }
        public string? TzNo { get; set; }
        public DateOnly? TzDd { get; set; }
        public string? MrpNo { get; set; }
        public string? MoNo { get; set; }
        public string? Unit { get; set; }
        public int? Qty { get; set; }
        public string? ZcNo { get; set; }
        public DateTime? StaDd { get; set; }
        public DateTime? EndDd { get; set; }
        public string? Dep { get; set; }
        public string? Rrem { get; set; }
        public DateOnly? ModifyDd { get; set; }
    }
}
