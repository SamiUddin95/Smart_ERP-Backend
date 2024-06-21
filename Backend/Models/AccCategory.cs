using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AccCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AccountTypeId { get; set; }
        public string ManualCode { get; set; }
        public string Priority { get; set; }
    }
}
