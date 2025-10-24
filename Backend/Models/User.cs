using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public int? Address { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? Salary { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
    }
}
