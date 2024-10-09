using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
