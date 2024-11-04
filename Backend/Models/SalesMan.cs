using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SALES_MAN")]
    public partial class SalesMan
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("SALES_MAN_TYPE_ID")]
        public int? SalesManTypeId { get; set; }
        [Column("IS_ACTIVE", TypeName = "nchar(10)")]
        public string IsActive { get; set; }
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
    }
}
