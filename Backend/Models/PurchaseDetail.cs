﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_DETAIL")]
    public partial class PurchaseDetail
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("PURCHASE_ID")]
        public int? PurchaseId { get; set; }
        [Column("BARCODE")]
        [StringLength(255)]
        public string Barcode { get; set; }
        [Column("ITEM_ID")]
        public int? ItemId { get; set; }
        [Column("QUANTITY")]
        public int? Quantity { get; set; }
        [Column("BONUS_QUANTITY")]
        public int? BonusQuantity { get; set; }
        [Column("PURCHASE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? PurchasePrice { get; set; }
        [Column("DISCOUNT_BY_PERCENT", TypeName = "decimal(5, 2)")]
        public decimal? DiscountByPercent { get; set; }
        [Column("DISCOUNT_BY_VALUE", TypeName = "decimal(10, 2)")]
        public decimal? DiscountByValue { get; set; }
        [Column("TOTAL", TypeName = "decimal(10, 2)")]
        public decimal? Total { get; set; }
        [Column("GST_BY_PERCENT", TypeName = "decimal(5, 2)")]
        public decimal? GstByPercent { get; set; }
        [Column("GST_BY_VALUE", TypeName = "decimal(10, 2)")]
        public decimal? GstByValue { get; set; }
        [Column("TOTAL_WITH_GST", TypeName = "decimal(10, 2)")]
        public decimal? TotalWithGst { get; set; }
        [Column("NET_RATE", TypeName = "decimal(10, 2)")]
        public decimal? NetRate { get; set; }
        [Column("MARGIN_PERCENT", TypeName = "decimal(19, 2)")]
        public decimal? MarginPercent { get; set; }
        [Column("SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? SalePrice { get; set; }
        [Column("SALE_DISCOUNT_BY_VALUE", TypeName = "decimal(10, 2)")]
        public decimal? SaleDiscountByValue { get; set; }
        [Column("NET_SALE_PRICE", TypeName = "decimal(10, 2)")]
        public decimal? NetSalePrice { get; set; }
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
        [Column("ITEM_NAME")]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Column("NET_QUANTITY")]
        public int? NetQuantity { get; set; }
        [Column("SUB_TOTAL", TypeName = "decimal(19, 2)")]
        public decimal? SubTotal { get; set; }
        [Column("TOTAL_INC_DISC", TypeName = "decimal(19, 2)")]
        public decimal? TotalIncDisc { get; set; }
        [Column("TOTAL_INC_GST", TypeName = "decimal(19, 2)")]
        public decimal? TotalIncGst { get; set; }
        [Column("NET_SALE_TOTAL", TypeName = "decimal(10, 2)")]
        public decimal? NetSaleTotal { get; set; }
        [Column("Total_Sale_Price", TypeName = "decimal(10, 2)")]
        public decimal? TotalSalePrice { get; set; }
    }
}
