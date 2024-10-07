using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class GroupPermission
    {
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
    }
}
