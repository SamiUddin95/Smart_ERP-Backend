using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ITEM_MANUFACTURER")]
    public partial class ItemManufacturer
    {
        public ItemManufacturer()
        {
            ItemItems = new HashSet<ItemItems>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("TELEPHONENO")]
        [StringLength(20)]
        public string Telephoneno { get; set; }
        [Column("TELEPHONENO2")]
        [StringLength(20)]
        public string Telephoneno2 { get; set; }
        [Column("EMAIL")]
        [StringLength(80)]
        public string Email { get; set; }

        [InverseProperty("Manufacturer")]
        public ICollection<ItemItems> ItemItems { get; set; }
    }
}
