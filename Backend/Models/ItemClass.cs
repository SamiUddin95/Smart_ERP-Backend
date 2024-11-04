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
            Item = new HashSet<Item>();
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

        [ForeignKey("CategoryId")]
        [InverseProperty("ItemClass")]
        public ItemCategory Category { get; set; }
        [InverseProperty("Class")]
        public ICollection<Item> Item { get; set; }
    }
}
