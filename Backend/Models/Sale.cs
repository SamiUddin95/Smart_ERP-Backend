using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE")]
    public partial class Sale
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("GROSS_SALE", TypeName = "decimal(19, 2)")]
        public decimal? GrossSale { get; set; }
        [Column("DISCOUNT_PERC", TypeName = "decimal(19, 2)")]
        public decimal? DiscountPerc { get; set; }
        [Column("DISCOUNT_VALUE", TypeName = "decimal(19, 2)")]
        public decimal? DiscountValue { get; set; }
        [Column("GRAND_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? GrandTotal { get; set; }
        [Column("RETURN", TypeName = "decimal(19, 2)")]
        public decimal? Return { get; set; }
        [Column("EARNED_POINTS", TypeName = "decimal(19, 2)")]
        public decimal? EarnedPoints { get; set; }
        [Column("NET_SALE_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? NetSaleTotal { get; set; }
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
        [Column("FLAT_DISC")]
        public decimal? FlatDisc { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("CASH_RECEIVED", TypeName = "decimal(19, 2)")]
        public decimal? CashReceived { get; set; }
        [Column("CASH_CHARGED", TypeName = "decimal(19, 2)")]
        public decimal? CashCharged { get; set; }
        [Column("CASH_BACK", TypeName = "decimal(19, 2)")]
        public decimal? CashBack { get; set; }
        [Column("INVOICE_BALANCE", TypeName = "decimal(19, 2)")]
        public decimal? InvoiceBalance { get; set; }
        [Column("INVOICE_TYPE")]
        [StringLength(50)]
        public string InvoiceType { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
    }
}
