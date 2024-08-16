using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class MeterParameterMa
    {
        public int Id { get; set; }  // 對應 id 欄位
        public string? MeterNo { get; set; }  // 對應 meter_no 欄位
        
        public string? IpAddress { get; set; }  // 對應 ip_address 欄位
        public string? RegLocation { get; set; }  // 對應 reg_location 欄位
        public int RegLength { get; set; }  // 對應 reg_length 欄位
        public string? ParaNo { get; set; }  // 對應 para_no 欄位
        public string? ParaName { get; set; }  // 對應 para_name 欄位
        public string? ParaFieldName { get; set; }  // 對應 para_field_name 欄位
        public string? DataType { get; set; }  // 對應 data_type 欄位
        public string? Unit { get; set; }  // 對應 unit 欄位
        public string? Sign { get; set; }  // 對應 sign 欄位
        public string? Sort { get; set; }  // 對應 sort 欄位
        public bool IsEnable { get; set; }  // 對應 is_enable 欄位
        public string? Note { get; set; }  // 對應 note 欄位
        public DateTime? CreatedAt { get; set; }  // 對應 created_at 欄位
        public DateTime? UpdatedAt { get; set; }  // 對應 updated_at 欄位
    }
}
