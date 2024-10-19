using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM_BRAND")]
    public partial class ItemBrand
    {
        public ItemBrand()
        {
            Item = new HashSet<Item>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
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

        [InverseProperty("Brand")]
        public ICollection<Item> Item { get; set; }
    }
}
