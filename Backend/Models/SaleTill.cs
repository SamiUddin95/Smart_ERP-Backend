using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALE_TILL")]
    public partial class SaleTill
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("TILL_OPEN_DATE_TIME")]
        [StringLength(100)]
        public string TillOpenDateTime { get; set; }
        [Column("TILL_CLOSE_DATE_TIME")]
        [StringLength(100)]
        public string TillCloseDateTime { get; set; }
        [Column("TILL_OPEN_AMOUNT")]
        public decimal? TillOpenAmount { get; set; }
        [Column("TILL_CLOSE_AMOUNT")]
        public decimal? TillCloseAmount { get; set; }
        [Column("CASH_SALE")]
        public decimal? CashSale { get; set; }
        [Column("CREDIT_SALE")]
        public decimal? CreditSale { get; set; }
        [Column("NET_SALE")]
        public decimal? NetSale { get; set; }
        [Column("DIFFERENCE")]
        public decimal? Difference { get; set; }
        [Column("EXCESS_SHORT")]
        [StringLength(50)]
        public string ExcessShort { get; set; }
        [Column("TILL_NO")]
        [StringLength(100)]
        public string TillNo { get; set; }
        [Column("TILL_NAME")]
        [StringLength(200)]
        public string TillName { get; set; }
        [Column("NOTES")]
        public string Notes { get; set; }
        [Column("SALE_TILL_ID")]
        public int? SaleTillId { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("LOCATION_ID")]
        public int? LocationId { get; set; }
    }
}
