using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("JOURNAL_VOUCHER")]
    public partial class JournalVoucher
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("DATETIME")]
        [StringLength(100)]
        public string Datetime { get; set; }
        [Column("CREATION_DATE")]
        [StringLength(100)]
        public string CreationDate { get; set; }
        [Column("POSTING_DATE")]
        [StringLength(100)]
        public string PostingDate { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("LOCATION")]
        [StringLength(100)]
        public string Location { get; set; }
        [Column("REFERENCE_NO")]
        [StringLength(100)]
        public string ReferenceNo { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("CREATED_BY")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("POSTED_BY")]
        [StringLength(100)]
        public string PostedBy { get; set; }
        [Column("ACCOUNT_BALANCE")]
        public decimal? AccountBalance { get; set; }
        [Column("AMOUNT")]
        public decimal? Amount { get; set; }
        [Column("MODIFIED_BY")]
        [StringLength(100)]
        public string ModifiedBy { get; set; }
    }
}
