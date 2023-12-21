using System;
using System.Collections.Generic;

namespace CopaCmd.Models
{
    public partial class ShiftTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Time { get; set; } = null!;
    }
}
