using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM_CATEGORY")]
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            ItemClass = new HashSet<ItemClass>();
            ItemItems = new HashSet<ItemItems>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("IS_ACTIVE")]
        public int IsActive { get; set; }
        [Column("PRIORITY")]
        public int? Priority { get; set; }
        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }
        [Column("HEIGHT")]
        public int? Height { get; set; }
        [Column("WIDTH")]
        public int? Width { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(550)]
        public string Description { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("ItemCategory")]
        public Department Department { get; set; }
        [ForeignKey("IsActive")]
        [InverseProperty("ItemCategory")]
        public Active IsActiveNavigation { get; set; }
        [InverseProperty("Category")]
        public ICollection<ItemClass> ItemClass { get; set; }
        [InverseProperty("Category")]
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
