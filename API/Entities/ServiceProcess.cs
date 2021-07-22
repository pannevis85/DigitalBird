using System;

namespace API.Entities
{
    public class ServiceProcess
    {
        public int Id { get; set; }
        public ServiceProcessType ProcessType {get;set;}
        public int? ProcessTypeId {get;set;}
        public string ProcessTypeName { get; set; }
        public string Status { get; set; } = "active";
        public string Category { get; set; }
        public string Activity { get; set; }
        public string Note { get; set; }
        public bool GdprRequirement { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
