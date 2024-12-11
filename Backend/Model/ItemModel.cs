using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string AliasName { get; set; }
        public string ItemName { get; set; }
        public int PurchasePrice { get; set; }
        public int? SalePrice { get; set; }
        public int CategoryId { get; set; }
        public int ClassId { get; set; }
        public int ManufacturerId { get; set; }
        public string Remarks { get; set; }
        public int? RecentPurchase { get; set; }
        public int BrandId { get; set; }
        public int? Discflat { get; set; }
        public int Lockdisc { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public List<AlternateItemModel> alternateItem { get; set; }

    }
    public class AlternateItemModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string AlternateItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Saledisc { get; set; }
        public string Remarks { get; set; }
        public string Barcode { get; set; }
        public decimal? NetSalePrice { get; set; }
    }
}
