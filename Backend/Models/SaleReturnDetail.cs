using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SaleReturnDetail
    {
        public long Id { get; set; }
        public long? SaleReturnId { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int? Qty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetSalePrice { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
