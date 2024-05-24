using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM_CLASS")]
    public partial class ItemClass
    {
        public ItemClass()
        {
            ItemItems = new HashSet<ItemItems>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("DEPARTMENT_ID")]
        public int? DepartmentId { get; set; }
        [Column("CATEGORY_ID")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("ItemClass")]
        public ItemCategory Category { get; set; }
        [ForeignKey("DepartmentId")]
        [InverseProperty("ItemClass")]
        public Department Department { get; set; }
        [InverseProperty("Class")]
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
