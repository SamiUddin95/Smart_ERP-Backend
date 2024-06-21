using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class AccGroup
    {
        public int Id { get; set; }
        public int GroupCategoryId { get; set; }
        public int AccountTypeId { get; set; }
        public string ManualCode { get; set; }
        public string Priority { get; set; }
    }
}
