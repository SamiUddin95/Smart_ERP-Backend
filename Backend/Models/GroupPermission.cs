using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("GROUP_PERMISSION")]
    public partial class GroupPermission
    {
        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        [Column("PERMISSION_ID")]
        public int PermissionId { get; set; }
    }
}
