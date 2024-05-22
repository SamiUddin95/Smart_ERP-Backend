using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PartyProductDetail
    {
        public int Id { get; set; }
        public int? PartyId { get; set; }
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int? Qty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FlatDiscOnEachQty { get; set; }
        public string Gst { get; set; }
        public decimal? Discper2 { get; set; }
        public decimal? Gstper2 { get; set; }
        public string Remarks { get; set; }
    }
}
