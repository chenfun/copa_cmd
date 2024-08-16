using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CopaCmd.Models
{
    public partial class ErpDataEmu
    {
        public int Id { get; set; }
        
        [JsonProperty("MO_NO")]
        public string? MoNo { get; set; }
        [JsonProperty("MO_DD")]
        public string? MoDd { get; set; }
        [JsonProperty("MRP_NO")]
        public string? MrpNo { get; set; }
        [JsonProperty("SO_NO")]
        public string? SoNo { get; set; }
        [JsonProperty("UNIT")]
        public string? Unit { get; set; }
        [JsonProperty("QTY")]
        public float? Qty { get; set; }
        [JsonProperty("STA_DD")]
        public string? StaDd { get; set; }
        [JsonProperty("NEED_DD")]
        public string? NeedDd { get; set; }
        [JsonProperty("REM")]
        public string? Rem { get; set; }
        [JsonProperty("CUS_NO")]
        public string? CusNo { get; set; }
        [JsonProperty("CLS_DATE")]
        public string? ClsDate { get; set; }
        [JsonProperty("SPC")]
        public string? Spc { get; set; }
        [JsonProperty("CUS_OS_NO")]
        public string? CusOsNo { get; set; }
        [JsonProperty("MODIFY_DD")]
        public string? ModifyDd { get; set; }
        [JsonProperty("MODIFY_MAN")]
        public string? ModifyMan { get; set; }
        [JsonProperty("CAS_NO")]
        public string? CasNo { get; set; }
        [JsonProperty("MF_MO_001")]
        public string? MfMo001 { get; set; }
    }
}
