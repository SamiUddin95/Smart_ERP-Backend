using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("shop")]
    public partial class Shop
    {
        [Column("shop_id")]
        public int ShopId { get; set; }
        [Required]
        [Column("shop_name")]
        [StringLength(100)]
        public string ShopName { get; set; }
        [Required]
        [Column("shop_size")]
        [StringLength(100)]
        public string ShopSize { get; set; }
        [Required]
        [Column("shop_location")]
        [StringLength(100)]
        public string ShopLocation { get; set; }
        [Column("shop_type_id")]
        public int ShopTypeId { get; set; }
        [Column("agreement_start_date")]
        [StringLength(50)]
        public string AgreementStartDate { get; set; }
    }
}
