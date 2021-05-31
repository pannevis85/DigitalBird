using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Agency { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime Creation_date { get; set; }
        public DateTime LastActive_date { get; set; }
    }
}
