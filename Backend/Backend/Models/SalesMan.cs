using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class SalesMan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SalesManTypeId { get; set; }
        public string IsActive { get; set; }
    }
}
