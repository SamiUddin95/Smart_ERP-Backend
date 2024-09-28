using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AccGroup
    {
        public int Id { get; set; }
        public int AccountCategoryId { get; set; }
        public int AccountTypeId { get; set; }
        public string ManualCode { get; set; }
        public string Priority { get; set; }
        public string Name { get; set; }
    }
}
