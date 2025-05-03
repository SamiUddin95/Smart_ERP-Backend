using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ACC_GROUP")]
    public partial class AccGroup
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ACCOUNT_CATEGORY_ID")]
        public long AccountCategoryId { get; set; }
        [Column("ACCOUNT_TYPE_ID")]
        public int AccountTypeId { get; set; }
        [Column("MANUAL_CODE")]
        [StringLength(200)]
        public string ManualCode { get; set; }
        [Column("PRIORITY")]
        [StringLength(200)]
        public string Priority { get; set; }
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string UpdatedBy { get; set; }
        [Column("REMARKS")]
        [StringLength(500)]
        public string Remarks { get; set; }
        [Column("GROUP_NUMBER")]
        public int? GroupNumber { get; set; }

        [ForeignKey("AccountCategoryId")]
        [InverseProperty("AccGroup")]
        public AccCategory AccountCategory { get; set; }
    }
}
