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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
