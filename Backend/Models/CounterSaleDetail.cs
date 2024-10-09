using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class CounterSaleDetail
    {
        public long Id { get; set; }
        public long CounterSaleId { get; set; }
        public string BarCode { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? NetTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
