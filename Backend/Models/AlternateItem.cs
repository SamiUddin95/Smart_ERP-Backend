using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Alternate_Item")]
    public partial class AlternateItem
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Item_Id")]
        public int ItemId { get; set; }
        [Required]
        [Column("Alias_Name")]
        [StringLength(250)]
        public string AliasName { get; set; }
        public decimal Qty { get; set; }
        public decimal? SaleDiscPerc { get; set; }
        public decimal? SaleDiscFlat { get; set; }
        [Required]
        [StringLength(250)]
        public string Remarks { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("AlternateItem")]
        public Item IdNavigation { get; set; }
    }
}
