using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string Status { get; set; }
        public DateTime Creation_date { get; set; }
        public DateTime LastActive_date { get; set; }
    }
}
