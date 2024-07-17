using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseOrder
    {
        public long Id { get; set; }
        public int? PartyId { get; set; }
        public string DateOfInvoice { get; set; }
        public string Remarks { get; set; }
        public string CreatedAt { get; set; }
        public decimal? InvTotal { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? Disc { get; set; }
        public string Posted { get; set; }
        public int? ZeroQty { get; set; }
        public string ProjectionDays { get; set; }
        public string PurOrderTerm { get; set; }
    }
}
