using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Process
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Order_Priority { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public bool GDPR_Requirement { get; set; }
        public string Note { get; set; }
    }
}
