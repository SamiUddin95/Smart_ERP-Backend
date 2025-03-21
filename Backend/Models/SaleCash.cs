using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE_CASH")]
    public partial class SaleCash
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("TILL_OPEN_NO")]
        [StringLength(100)]
        public string TillOpenNo { get; set; }
        [Column("TILL_CLOSE_NO")]
        [StringLength(100)]
        public string TillCloseNo { get; set; }
        [Column("CASH_IN_DATE_TIME")]
        [StringLength(100)]
        public string CashInDateTime { get; set; }
        [Column("CASH_OUT_DATE_TIME")]
        [StringLength(100)]
        public string CashOutDateTime { get; set; }
        [Column("CASH_IN_AMOUNT")]
        public decimal? CashInAmount { get; set; }
        [Column("CASH_OUT_AMOUNT")]
        public decimal? CashOutAmount { get; set; }
        [Column("NOTES")]
        public string Notes { get; set; }
    }
}
