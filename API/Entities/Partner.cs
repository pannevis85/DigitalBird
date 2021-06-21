using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Partner
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Status { get; set; } ="active";
        public string Partner_group { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Agency { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
        
    }
}
