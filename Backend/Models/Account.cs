using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ACCOUNT")]
    public partial class Account
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("ACCOUNT_NUMBER")]
        public long AccountNumber { get; set; }
        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        [Column("SUB_GROUP_ID")]
        public int SubGroupId { get; set; }
        [Column("ACCOUNT_CATEGORY_ID")]
        public int AccountCategoryId { get; set; }
        [Column("ACCOUNT_TYPE_ID")]
        public int AccountTypeId { get; set; }
        [Column("MANUAL_CODE")]
        [StringLength(50)]
        public string ManualCode { get; set; }
        [Column("KIND_CODE")]
        [StringLength(50)]
        public string KindCode { get; set; }
        [Column("PRIORITY")]
        [StringLength(50)]
        public string Priority { get; set; }
        [Column("TYPE_ID")]
        public int? TypeId { get; set; }
        [Column("SUB_CD_TYPE_ID")]
        public int? SubCdTypeId { get; set; }
        [Column("DISC_NO")]
        [StringLength(100)]
        public string DiscNo { get; set; }
        [Column("BALANCE_LIMIT")]
        public decimal? BalanceLimit { get; set; }
        [Column("TAX_LIMIT")]
        public decimal? TaxLimit { get; set; }
        [Column("TAX_AMOUNT")]
        public decimal? TaxAmount { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("REMARKS")]
        [StringLength(200)]
        public string Remarks { get; set; }
    }
}
