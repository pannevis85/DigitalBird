using System;
using API.Entities;

namespace API.DTOs
{
    public class ProcessDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Category { get; set; }
        public string Activity { get; set; }
        public string Note { get; set; }
        public bool GdprRequirement { get; set; }
        public int SortOrder { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}