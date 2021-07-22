using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Status { get; set; } = "active";        
        public string VendorGroup { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
