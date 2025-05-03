using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AgreementType
    {
        public int AgreementTypeId { get; set; }
        public string AgreementName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
