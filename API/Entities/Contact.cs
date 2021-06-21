using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Status { get; set; } = "active";
        public Partner Partner { get; set; }
        public int? PartnerId { get; set; }      
        public string PartnerName { get; set; } 
        public string Title { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
