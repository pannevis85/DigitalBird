using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ServiceProcessType
    {
        public int Id { get; set; }        
        [Required]
        public string Name { get; set; }
        public string Status { get; set; } ="active";
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}