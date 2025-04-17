using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE_RETURN")]
    public partial class SaleReturn
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("GROSS_SALE_RETURN")]
        public decimal? GrossSaleReturn { get; set; }
        [Column("DISC_BY_PERCENT")]
        public decimal? DiscByPercent { get; set; }
        [Column("DISC_BY_VALUE")]
        public decimal? DiscByValue { get; set; }
        [Column("NET_SALE_RETURN_TOTAL")]
        public decimal? NetSaleReturnTotal { get; set; }
        [Column("GRAND_TOTAL")]
        public decimal? GrandTotal { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("DEDUCTION", TypeName = "decimal(19, 2)")]
        public decimal? Deduction { get; set; }
    }
}
