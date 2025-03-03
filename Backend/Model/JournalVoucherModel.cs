using Backend.Models;
using System.Collections.Generic;

namespace Backend.Model
{
    public class JournalVoucherModel
    {
        public int Id { get; set; }
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

        public List<JournalVoucherDtlModel> jurnlVuchrDtl { get; set; }

    } 
        public class JournalVoucherDtlModel
        {
        public long Id { get; set; }
        public long? JournalVoucherId { get; set; }
        public string DebitAccCode { get; set; }
        public string DebitAccName { get; set; }
        public string CreditAccCode { get; set; }
        public string CreditAccName { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
    }
}
