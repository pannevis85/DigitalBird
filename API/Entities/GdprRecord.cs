using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class GdprRecord
    {
        public int Id { get; set; }
        public string Status { get; set; } ="active";
        public int GdprRecordYear { get; set; } = DateTime.Now.Year;
        public string GdprCountry { get; set; }
        public string GGdprLaw { get; set; }
        public string GdprNote { get; set; }
        public string ContractLocation { get; set; }
        public string ContractStatus { get; set; }
        public Partner Partner { get; set; }
        public int? PartnerId { get; set; }
        public Contact Contact { get; set; } //optional
        public int? ContactId { get; set; } //optional
        public ServiceProcess Process { get; set; }
        public int? ProcessId { get; set; }
        public VendorService VendorService { get; set; }
        public int? VendorServiceId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}        
    }
}
