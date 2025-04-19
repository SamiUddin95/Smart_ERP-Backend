using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class JournalVoucherDetail
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
