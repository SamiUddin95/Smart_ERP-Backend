using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("user_type")]
    public partial class UserType
    {
        [Column("user_type_id")]
        public int UserTypeId { get; set; }
        [Column("user_type")]
        [StringLength(50)]
        public string UserType1 { get; set; }
    }
}
