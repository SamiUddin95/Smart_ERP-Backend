using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class MinimumQty
    {
        public long Id { get; set; }
        public long? Sno { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int? CurrentStock { get; set; }
        public decimal? NetRate { get; set; }
        public int? MinimumQty1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
