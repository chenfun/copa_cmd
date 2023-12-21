using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class Machinetype
    {
        public int Id { get; set; }
        public string? Typename { get; set; }
        public string? Ord { get; set; }
        public DateTime? Createtime { get; set; }
    }
}
