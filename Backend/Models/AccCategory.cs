using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ACC_CATEGORY")]
    public partial class AccCategory
    {
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("ACCOUNT_TYPE_ID")]
        public long AccountTypeId { get; set; }
        [Column("MANUAL_CODE")]
        [StringLength(50)]
        public string ManualCode { get; set; }
        [Column("PRIORITY")]
        [StringLength(50)]
        public string Priority { get; set; }
    }
}
