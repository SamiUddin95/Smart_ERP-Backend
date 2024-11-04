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
            Item = new HashSet<Item>();
            ItemClass = new HashSet<ItemClass>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("IS_ACTIVE")]
        public int IsActive { get; set; }
        [Column("PRIORITY")]
        [StringLength(50)]
        public string Priority { get; set; }
        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }
        [Column("HEIGHT")]
        public int? Height { get; set; }
        [Column("WIDTH")]
        public int? Width { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(550)]
        public string Description { get; set; }
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

        [InverseProperty("Category")]
        public ICollection<Item> Item { get; set; }
        [InverseProperty("Category")]
        public ICollection<ItemClass> ItemClass { get; set; }
    }
}
