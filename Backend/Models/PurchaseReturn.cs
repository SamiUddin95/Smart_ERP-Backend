using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseReturn
    {
        public long Id { get; set; }
        public long OrderNo { get; set; }
        public int PoCategroyId { get; set; }
        public string Date { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? GoDownId { get; set; }
        public int? Vehicle { get; set; }
        public string ProjectionDays { get; set; }
    }
}
