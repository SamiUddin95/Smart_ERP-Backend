using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PERMISSION")]
    public partial class Permission
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("PERMISSION_ID")]
        [StringLength(500)]
        public string PermissionId { get; set; }
    }
}
