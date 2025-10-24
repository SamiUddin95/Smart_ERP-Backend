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
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? PostedDate { get; set; }
        public string Status { get; set; }
        public string PostedBy { get; set; }
        public int? LocationId { get; set; }
        public string DeliveryStatus { get; set; }
        public string DeliveryDate { get; set; }
        public string PartyType { get; set; }
    }
}
