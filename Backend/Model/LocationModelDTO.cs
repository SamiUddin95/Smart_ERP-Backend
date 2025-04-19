using Backend.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Backend.Model
{
    public class LocationModelDTO
    {
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

        public List<TillLocationModel> tillLocation { get; set; }

        public class TillLocationModel
        {
            public long Id { get; set; }
            public int? LocationId { get; set; }
            public long? TillNumber { get; set; }
            public string Name { get; set; }

        }
        
    }
}
