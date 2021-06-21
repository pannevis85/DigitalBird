using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VendorService
    {
        public int Id { get; set; }
        public string Status { get; set; } = "active";
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime StartOfServiceYear { get; set; }
        public DateTime EndOfServiceYear { get; set; }
        public Partner Partner { get; set; }
        public int? PartnerId { get; set; }
        public Vendor Vendor { get; set; }
        public int? VendorId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
