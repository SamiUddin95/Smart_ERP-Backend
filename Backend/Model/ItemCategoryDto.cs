using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Model
{
    public class ItemCategoryDto
    {
        public int Id { get; set; }
        public long? Sno { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public string Priority { get; set; }
        public int? DepartmentId { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
