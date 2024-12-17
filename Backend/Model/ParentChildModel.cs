using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class ChildModel
    {
        public long? ItemId { get; set; }
        public List<ChildItemDto> ChildItems { get; set; }
    }

    public class ChildItemDto
    {
        public string Barcode { get; set; }
        public string ChildName { get; set; }
        public string Uom { get; set; }
        public int? Weight { get; set; }
        public decimal? NetCost { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? DiscPerc { get; set; }
        public decimal? DiscValue { get; set; }
        public decimal? Misc { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Cost { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
