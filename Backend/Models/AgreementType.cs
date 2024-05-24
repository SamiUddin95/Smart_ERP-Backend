using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("agreement_type")]
    public partial class AgreementType
    {
        [Column("agreement_type_id")]
        public int AgreementTypeId { get; set; }
        [Required]
        [Column("agreement_name")]
        [StringLength(50)]
        public string AgreementName { get; set; }
    }
}
