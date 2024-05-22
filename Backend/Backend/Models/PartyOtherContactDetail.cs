using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PartyOtherContactDetail
    {
        public int Id { get; set; }
        public int? PartyId { get; set; }
        public string CellNo { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string OfficeAddress { get; set; }
        public string ResAddress { get; set; }
        public string Remarks { get; set; }
    }
}
