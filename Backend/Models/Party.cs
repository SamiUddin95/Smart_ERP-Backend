using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Party
    {
        public int Id { get; set; }
        public string PartyName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string TelPhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string TaxRegNo { get; set; }
        public string Ntn { get; set; }
        public string Nic { get; set; }
        public int? AreaId { get; set; }
        public int? CityId { get; set; }
        public int? SubAreaId { get; set; }
        public string Address1 { get; set; }
        public string ContactPerson { get; set; }
        public int? CategoryId { get; set; }
        public int? DueDays { get; set; }
    }
}
