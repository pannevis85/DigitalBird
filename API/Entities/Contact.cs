using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime Record_date { get; set; }
        public Partner Partner { get; set; }
        [Required]
        public int Partner_Id { get; set; }
    }
}
