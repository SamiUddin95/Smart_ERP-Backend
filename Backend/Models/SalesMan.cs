using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SalesMan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SalesManTypeId { get; set; }
        public string IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
