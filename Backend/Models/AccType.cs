using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AccType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
