using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
