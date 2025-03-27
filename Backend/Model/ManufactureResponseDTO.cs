using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Model
{
    public class ManufactureResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephoneno { get; set; }
        public string Telephoneno2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public long? Sno { get; set; }
        public string Picture { get; set; }
    }
}
