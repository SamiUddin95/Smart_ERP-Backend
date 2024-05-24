using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PURCHASE_OPENING_PURCHASE")]
    public partial class PurchaseOpeningPurchase
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("DATE", TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("ACC_NAME")]
        [StringLength(50)]
        public string AccName { get; set; }
        [Column("GODOWN")]
        [MaxLength(50)]
        public byte[] Godown { get; set; }
        [Column("VEHICLENO")]
        [StringLength(50)]
        public string Vehicleno { get; set; }
        [Column("REMARKS")]
        [StringLength(50)]
        public string Remarks { get; set; }
        [Column("GSTMODE")]
        [StringLength(50)]
        public string Gstmode { get; set; }
        [Column("BARCODE")]
        [StringLength(50)]
        public string Barcode { get; set; }
        [Column("ITEMNAME")]
        [StringLength(50)]
        public string Itemname { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("BONUS")]
        [StringLength(50)]
        public string Bonus { get; set; }
        [Column("PURPRICE", TypeName = "decimal(18, 4)")]
        public decimal? Purprice { get; set; }
        [Column("DISC")]
        [StringLength(50)]
        public string Disc { get; set; }
        [Column("FLATDISC")]
        [StringLength(50)]
        public string Flatdisc { get; set; }
        [Column("TOTALEXCTAX")]
        [StringLength(50)]
        public string Totalexctax { get; set; }
        [Column("GST")]
        [StringLength(50)]
        public string Gst { get; set; }
        [Column("GSTVAL")]
        [StringLength(50)]
        public string Gstval { get; set; }
        [Column("TOTAL_INC_TAX")]
        [StringLength(50)]
        public string TotalIncTax { get; set; }
        [Column("SALEPRICE", TypeName = "decimal(18, 4)")]
        public decimal? Saleprice { get; set; }
        [Column("MARGIN")]
        [StringLength(50)]
        public string Margin { get; set; }
        [Column("MARKUP")]
        [StringLength(50)]
        public string Markup { get; set; }
        [Column("NETRATE")]
        [StringLength(50)]
        public string Netrate { get; set; }
        [Column("MISC")]
        [StringLength(50)]
        public string Misc { get; set; }
        [Column("DISC_FLAT_EN")]
        [StringLength(50)]
        public string DiscFlatEn { get; set; }
        [Column("STOCK")]
        [StringLength(50)]
        public string Stock { get; set; }
        [Column("RECENT_PUR_PRICE", TypeName = "decimal(18, 4)")]
        public decimal? RecentPurPrice { get; set; }
        [Column("TOTAL_STOCK")]
        [StringLength(50)]
        public string TotalStock { get; set; }
        [Column("AVG_PRICE", TypeName = "decimal(18, 4)")]
        public decimal? AvgPrice { get; set; }
        [Column("WITHHOLDING_TAX_PERC")]
        [StringLength(50)]
        public string WithholdingTaxPerc { get; set; }
        [Column("TOTAL_AMOUNT", TypeName = "decimal(18, 4)")]
        public decimal? TotalAmount { get; set; }
        [Column("QTY_PACK")]
        [StringLength(50)]
        public string QtyPack { get; set; }
        [Column("LOOSE_QTY")]
        [StringLength(50)]
        public string LooseQty { get; set; }
        [Column("TOTAL_QTY")]
        [StringLength(50)]
        public string TotalQty { get; set; }
        [Column("BONUS_QTY")]
        [StringLength(50)]
        public string BonusQty { get; set; }
        [Column("DISC_PER_VALUE")]
        [StringLength(50)]
        public string DiscPerValue { get; set; }
        [Column("DISC_FLAT_VALUE")]
        [StringLength(50)]
        public string DiscFlatValue { get; set; }
        [Column("DISC_VALUE2")]
        [StringLength(50)]
        public string DiscValue2 { get; set; }
        [Column("GST_VALUE2")]
        [StringLength(50)]
        public string GstValue2 { get; set; }
        [Column("GRANT_TOTAL", TypeName = "decimal(18, 4)")]
        public decimal? GrantTotal { get; set; }
    }
}
