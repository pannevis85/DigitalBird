using System;

namespace API.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ProcessType ProcessType {get;set;}
        public int? ProcessTypeId {get;set;}
        public int OrderPriority { get; set; }
        public string Category { get; set; }
        public string Activity { get; set; }
        public bool GdprRequirement { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
