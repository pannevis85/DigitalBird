using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VendorService
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int StartOfServiceYear { get; set; }
        public int EndOfServiceYear { get; set; }
        public DateTime Record_date { get; set; }
        public Partner Partner { get; set; }
        [Required]
        public int Partner_Id { get; set; }
        public Vendor Vendor { get; set; }
        [Required]
        public int Vendor_Id { get; set; }
    }
}
