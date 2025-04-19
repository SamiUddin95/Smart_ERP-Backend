using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("USER_GROUP")]
    public partial class UserGroup
    {
        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        [Column("USER_ID", TypeName = "nchar(10)")]
        public string UserId { get; set; }
    }
}
