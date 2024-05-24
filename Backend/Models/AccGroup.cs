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
        [Column("GROUP_CATEGORY_ID")]
        public int GroupCategoryId { get; set; }
        [Column("ACCOUNT_TYPE_ID")]
        public int AccountTypeId { get; set; }
        [Column("MANUAL_CODE")]
        [StringLength(200)]
        public string ManualCode { get; set; }
        [Column("PRIORITY")]
        [StringLength(200)]
        public string Priority { get; set; }
    }
}
