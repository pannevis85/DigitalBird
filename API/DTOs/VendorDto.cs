using System;
using API.Entities;

namespace API.DTOs
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }   
        public string VendorGroup { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}