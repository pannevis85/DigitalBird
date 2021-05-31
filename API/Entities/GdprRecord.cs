using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class GdprRecord
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        
        [Required]
        public int Gdpr_record_year { get; set; }
        [Required]
        public string Contract_Location { get; set; }
        [Required]
        public string GDPR_Country { get; set; }
        [Required]
        public string GDPR_Law { get; set; }
        [Required]
        public string GDPR_Note { get; set; }
        public string Archive_Status { get; set; }
        public Partner Partner { get; set; }
        [Required]
        public int Partner_Id { get; set; }
        public Contact Contact { get; set; } //optional
        public int? Contact_Id { get; set; } //optional
        public Process Process { get; set; }
        [Required]
        public int Process_Id { get; set; }
        public Vendor Vendor { get; set; }
        [Required]
        public int Vendor_Id { get; set; }
        public VendorService VendorService { get; set; }
        [Required]
        public int VendorService_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Transaction_User { get; set; }
    }
}
