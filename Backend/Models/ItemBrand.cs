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
            ItemItems = new HashSet<ItemItems>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty("Brand")]
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
