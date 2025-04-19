using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_RETURN")]
    public partial class PurchaseReturn
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("ORDER_NO")]
        public long OrderNo { get; set; }
        [Column("PARTY_ID")]
        public int PartyId { get; set; }
        [Column("DATE")]
        [StringLength(50)]
        public string Date { get; set; }
        [Column("USER_ID")]
        public int? UserId { get; set; }
        [Column("PUR_SNO")]
        [StringLength(50)]
        public string PurSno { get; set; }
        [Column("TOTAL_QTY")]
        public int? TotalQty { get; set; }
        [Column("LOOSE_QTY")]
        public int? LooseQty { get; set; }
        [Column("BONUS_QTY")]
        public int? BonusQty { get; set; }
        [Column("QTY_PACK")]
        public int? QtyPack { get; set; }
        [Column("TOTAL_EXC_TAX")]
        public decimal? TotalExcTax { get; set; }
        [Column("TOTAL_INC_TAX")]
        public decimal? TotalIncTax { get; set; }
        [Column("AVG_PRICE")]
        public decimal? AvgPrice { get; set; }
        [Column("TOTAL_STOCK")]
        public decimal? TotalStock { get; set; }
        [Column("GRAND_TOTAL")]
        public decimal? GrandTotal { get; set; }
        [Column("TOTAL")]
        public decimal? Total { get; set; }
        [Column("ITEM_TYPE")]
        [StringLength(50)]
        public string ItemType { get; set; }
        [Column("DISC")]
        public decimal? Disc { get; set; }
        [Column("FLAT_DISC")]
        public decimal? FlatDisc { get; set; }
        [Column("CREATED_AT", TypeName = "date")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "date")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public string Remarks { get; set; }
        public DateTime? PostedDate { get; set; }
        public string PostUnpostStatus { get; set; }
        public string PostedBy { get; set; }
    }
}
