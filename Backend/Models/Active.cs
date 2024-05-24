using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ACTIVE")]
    public partial class Active
    {
        public Active()
        {
            ItemCategory = new HashSet<ItemCategory>();
            ItemItems = new HashSet<ItemItems>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("IS_ACTIVE")]
        [StringLength(50)]
        public string IsActive { get; set; }

        [InverseProperty("IsActiveNavigation")]
        public ICollection<ItemCategory> ItemCategory { get; set; }
        [InverseProperty("LockdiscNavigation")]
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
