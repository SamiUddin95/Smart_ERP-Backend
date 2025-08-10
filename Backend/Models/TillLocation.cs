using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class TillLocation
    {
        public long Id { get; set; }
        public int? LocationId { get; set; }
        public long? TillNumber { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }
    }
}
