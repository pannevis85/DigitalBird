using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ProcessType
    {
        public int Id { get; set; }
        public string Status { get; set; } ="active";
        [Required]
        public string TypeOfProcess { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}