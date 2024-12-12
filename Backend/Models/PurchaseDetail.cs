using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseDetail
    {
        public int Id { get; set; }
        public int? PurchaseId { get; set; }
        public string Barcode { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public int? BonusQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountByPercent { get; set; }
        public decimal? DiscountByValue { get; set; }
        public decimal? Total { get; set; }
        public decimal? GstByPercent { get; set; }
        public decimal? GstByValue { get; set; }
        public decimal? TotalWithGst { get; set; }
        public decimal? NetRate { get; set; }
        public decimal? MarginPercent { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? SaleDiscountByValue { get; set; }
        public decimal? NetSalePrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ItemName { get; set; }
        public int? NetQuantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalIncDisc { get; set; }
        public decimal? TotalIncGst { get; set; }
        public decimal? NetSaleTotal { get; set; }
    }
}
