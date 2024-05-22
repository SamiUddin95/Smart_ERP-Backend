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
        public int? Phone { get; set; }
        public int? Address { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string JoiningDate { get; set; }
    }
}
