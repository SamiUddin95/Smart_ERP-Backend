using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class UserType
    {
        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
