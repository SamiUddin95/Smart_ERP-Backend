using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Location
    {
        public Location()
        {
            TillLocation = new HashSet<TillLocation>();
        }

        public int Id { get; set; }
        public long? Serialnumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? RoyalityPercent { get; set; }

        public ICollection<TillLocation> TillLocation { get; set; }
    }
}
