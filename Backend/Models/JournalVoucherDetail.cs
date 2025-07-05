using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("JOURNAL_VOUCHER_DETAIL")]
    public partial class JournalVoucherDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("JOURNAL_VOUCHER_ID")]
        public long? JournalVoucherId { get; set; }
        [Column("DEBIT_ACC_CODE")]
        [StringLength(100)]
        public string DebitAccCode { get; set; }
        [Column("DEBIT_ACC_NAME")]
        [StringLength(100)]
        public string DebitAccName { get; set; }
        [Column("CREDIT_ACC_CODE")]
        [StringLength(100)]
        public string CreditAccCode { get; set; }
        [Column("CREDIT_ACC_NAME")]
        [StringLength(100)]
        public string CreditAccName { get; set; }
        [Column("REF_NO")]
        [StringLength(100)]
        public string RefNo { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("AMOUNT")]
        public decimal? Amount { get; set; }
    }
}
