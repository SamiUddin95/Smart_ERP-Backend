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
            Item = new HashSet<Item>();
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
        public string Address { get; set; }
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

        [InverseProperty("Manufacturer")]
        public ICollection<Item> Item { get; set; }
    }
}
