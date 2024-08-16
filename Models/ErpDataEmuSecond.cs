using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CopaCmd.Models
{
    public partial class ErpDataEmuSecond
    {
        public int Id { get; set; }
        [JsonProperty("TZ_NO")]
        public string? TzNo { get; set; }
        [JsonProperty("TZ_DD")]
        public DateTime? TzDd { get; set; }
        [JsonProperty("MRP_NO")]
        public string? MrpNo { get; set; }
        [JsonProperty("MO_NO")]
        public string? MoNo { get; set; }
        [JsonProperty("UNIT")]
        public string? Unit { get; set; }
        [JsonProperty("QTY")]
        public float? Qty { get; set; }
        [JsonProperty("ZC_NO")]
        public string? ZcNo { get; set; }
        [JsonProperty("STA_DD")]
        public DateTime? StaDd { get; set; }
        [JsonProperty("END_DD")]
        public DateTime? EndDd { get; set; }
        [JsonProperty("DEP")]
        public string? Dep { get; set; }
        [JsonProperty("RREM")]
        public string? Rrem { get; set; }
        [JsonProperty("MODIFY_DD")]
        public DateTime? ModifyDd { get; set; }
    }
}
