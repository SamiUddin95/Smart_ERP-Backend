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
    }
}
