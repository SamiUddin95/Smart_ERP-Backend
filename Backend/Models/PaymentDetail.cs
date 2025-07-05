using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PAYMENT_DETAIL")]
    public partial class PaymentDetail
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("SALE_ID")]
        public long? SaleId { get; set; }
        [Column("CASH_CHARGED")]
        public decimal? CashCharged { get; set; }
        [Column("CASH_RECEIVED")]
        public decimal? CashReceived { get; set; }
        [Column("CASH_BACK")]
        public decimal? CashBack { get; set; }
        [Column("NET_TOTAL")]
        public decimal? NetTotal { get; set; }
        [Column("INVOICE_BALANCE")]
        public decimal? InvoiceBalance { get; set; }
        [Column("AMOUNT_WORDS")]
        [StringLength(500)]
        public string AmountWords { get; set; }
        [Column("INV_TYPE")]
        [StringLength(30)]
        public string InvType { get; set; }
        [Column("EXTRA_CHARGES", TypeName = "decimal(18, 0)")]
        public decimal? ExtraCharges { get; set; }
        [Column("EXTRA_CHARGES_PER")]
        public decimal? ExtraChargesPer { get; set; }
        [Column("MACHINE_NAME")]
        [StringLength(100)]
        public string MachineName { get; set; }
        [Column("CREDIT_AMOUNT")]
        public decimal? CreditAmount { get; set; }
        [Column("CARD_NAME")]
        [StringLength(100)]
        public string CardName { get; set; }
        [Column("CARD_NUMBER")]
        [StringLength(100)]
        public string CardNumber { get; set; }
        [Column("FINAL_AMOUNT", TypeName = "decimal(19, 2)")]
        public decimal? FinalAmount { get; set; }
        [Column("REMAINING_CREDIT_AMOUNT")]
        public decimal? RemainingCreditAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
