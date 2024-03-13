using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class ErpDataEmu
    {
        public int Id { get; set; }
        public string? MoNo { get; set; }
        public DateOnly? MoDd { get; set; }
        public string? MrpNo { get; set; }
        public string? SoNo { get; set; }
        public string? Unit { get; set; }
        public int? Qty { get; set; }
        public DateOnly? StaDd { get; set; }
        public DateOnly? NeedDd { get; set; }
        public string? Rem { get; set; }
        public string? CusNo { get; set; }
        public DateOnly? ClsDate { get; set; }
        public string? Spc { get; set; }
        public string? CusOsNo { get; set; }
        public DateOnly? ModifyDd { get; set; }
        public string? ModifyMan { get; set; }
        public string? CasNo { get; set; }
        public string? MfMo001 { get; set; }
    }
}
