using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Active
    {
        public int Id { get; set; }
        public string IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
