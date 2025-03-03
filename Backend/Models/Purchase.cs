using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE")]
    public partial class Purchase
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("VENDOR_ID")]
        public int? VendorId { get; set; }
        [Column("REMARKS")]
        [StringLength(255)]
        public string Remarks { get; set; }
        [Column("INVOICE_NO")]
        [StringLength(100)]
        public string InvoiceNo { get; set; }
        [Column("RECENT_PURCHASE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? RecentPurchasePrice { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? SalePrice { get; set; }
        [Column("ITEMS_QUANTITY")]
        public int? ItemsQuantity { get; set; }
        [Column("TOTAL_DISCOUNT", TypeName = "decimal(10, 2)")]
        public decimal? TotalDiscount { get; set; }
        [Column("TOTAL_GST", TypeName = "decimal(10, 2)")]
        public decimal? TotalGst { get; set; }
        [Column("BILL_TOTAL", TypeName = "decimal(10, 2)")]
        public decimal? BillTotal { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column("NET_COST_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? NetCostTotal { get; set; }
        [Column("NET_SALE_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? NetSaleTotal { get; set; }
        [Column("NET_QUANTITY")]
        public int? NetQuantity { get; set; }
        [Column("TOTAL_DISC", TypeName = "decimal(19, 2)")]
        public decimal? TotalDisc { get; set; }
        [Column("NET_PROFIT_IN_VALUE", TypeName = "decimal(19, 2)")]
        public decimal? NetProfitInValue { get; set; }
        [Column("POSTED_DATE", TypeName = "datetime")]
        public DateTime? PostedDate { get; set; }
        [Column("Total_Sale_Price", TypeName = "decimal(10, 2)")]
        public decimal? TotalSalePrice { get; set; }
    }
}
