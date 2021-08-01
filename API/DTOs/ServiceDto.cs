using System;
using API.Entities;

namespace API.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}