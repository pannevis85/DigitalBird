using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Name { get; set; }
        public string Vendor_group { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Record_date { get; set; }
    }
}
