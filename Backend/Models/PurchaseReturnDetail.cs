using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseReturnDetail
    {
        public long Id { get; set; }
        public long? OrderReturnId { get; set; }
        public string Barcode { get; set; }
        public int? ItemId { get; set; }
        public int? Qty { get; set; }
        public decimal? FullRate { get; set; }
        public decimal? Disc { get; set; }
        public decimal? FlatDisc { get; set; }
        public decimal? Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
