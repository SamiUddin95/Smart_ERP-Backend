using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("user")]
    public partial class User
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("user_type_id")]
        public int UserTypeId { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("phone")]
        public int? Phone { get; set; }
        [Column("address")]
        public int? Address { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("joining_date")]
        [StringLength(50)]
        public string JoiningDate { get; set; }
    }
}
