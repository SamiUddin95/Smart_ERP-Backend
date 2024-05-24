using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ACC_TYPE")]
    public partial class AccType
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
