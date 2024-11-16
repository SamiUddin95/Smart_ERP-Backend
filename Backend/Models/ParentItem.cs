using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class ParentItem
    {
        public ParentItem()
        {
            ChildItem = new HashSet<ChildItem>();
        }

        public long Id { get; set; }
        public int? ItemId { get; set; }
        public string Barcode { get; set; }
        public string ParentName { get; set; }
        public string Uom { get; set; }
        public int? Weight { get; set; }
        public decimal? NetCost { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? DiscPerc { get; set; }
        public decimal? DiscValue { get; set; }
        public decimal? Misc { get; set; }
        public decimal? NetSalePrice { get; set; }
        public decimal? Profit { get; set; }
        public decimal? ManualSalePrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Item Item { get; set; }
        public ICollection<ChildItem> ChildItem { get; set; }
    }
}
