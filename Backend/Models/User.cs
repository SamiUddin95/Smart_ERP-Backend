using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("user")]
    public partial class User
    {
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("USER_TYPE_ID")]
        public int UserTypeId { get; set; }
        [Required]
        [Column("PASSWORD")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("PHONE")]
        public long? Phone { get; set; }
        [Column("ADDRESS")]
        public int? Address { get; set; }
        [Column("GENDER")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; }
        [Column("JOINING_DATE", TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
        [Column("SALARY")]
        public decimal? Salary { get; set; }
    }
}
