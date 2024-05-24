using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("shop_type")]
    public partial class ShopType
    {
        [Column("shop_type_id")]
        public int ShopTypeId { get; set; }
        [Required]
        [Column("shop_type")]
        [StringLength(50)]
        public string ShopType1 { get; set; }
    }
}
