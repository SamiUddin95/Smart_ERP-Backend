using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("COUNTER_SALE")]
    public partial class CounterSale
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("GROSS_SALE", TypeName = "decimal(19, 2)")]
        public decimal? GrossSale { get; set; }
        [Column("DISCOUNT", TypeName = "decimal(19, 2)")]
        public decimal? Discount { get; set; }
        [Column("FLAT_DISCOUNT", TypeName = "decimal(19, 2)")]
        public decimal? FlatDiscount { get; set; }
        [Column("TOTAL_DISCOUNT", TypeName = "decimal(19, 2)")]
        public decimal? TotalDiscount { get; set; }
        [Column("MISC", TypeName = "decimal(19, 2)")]
        public decimal? Misc { get; set; }
        [Column("GRAND_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? GrandTotal { get; set; }
        [Column("RETURN", TypeName = "decimal(19, 2)")]
        public decimal? Return { get; set; }
        [Column("EARNED_POINTS", TypeName = "decimal(19, 2)")]
        public decimal? EarnedPoints { get; set; }
        [Column("NET_AMOUNT", TypeName = "decimal(19, 2)")]
        public decimal? NetAmount { get; set; }
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
    }
}
