using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string Remarks { get; set; }
        public string InvoiceNo { get; set; }
        public string CreatedBy { get; set; }
        public decimal? RecentPurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ItemsQuantity { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? BillTotal { get; set; }
        public List<PurchaseDetailModel> PurchaseDetailModel { get; set; }

    }
    public partial class PurchaseDetailModel
    {
        public int Id { get; set; }
        public int? PurchaseId { get; set; }
        public string Barcode { get; set; }
        public int ItemId { get; set; }
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
        public string CreatedBy { get; set; }
    }
}
