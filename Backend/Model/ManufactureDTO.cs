using Backend.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Model
{
    public class ManufactureDTO
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
        public IFormFile Picture { get; set; }
    }
}
