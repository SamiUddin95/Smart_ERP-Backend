using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class JournalVoucher
    {
        public long Id { get; set; }
        public string Datetime { get; set; }
        public string CreationDate { get; set; }
        public string PostingDate { get; set; }
        public int? UserId { get; set; }
        public string Location { get; set; }
        public string ReferenceNo { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string PostedBy { get; set; }
        public decimal? AccountBalance { get; set; }
        public decimal? Amount { get; set; }
        public string ModifiedBy { get; set; }
    }
}
