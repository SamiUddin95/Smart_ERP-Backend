using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("SUB_AREA")]
    public partial class SubArea
    {
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("ID")]
        public int Id { get; set; }
    }
}
