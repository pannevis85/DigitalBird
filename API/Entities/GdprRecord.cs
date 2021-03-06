using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class GdprRecord
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int GdprRecordYear { get; set; }
        public string GdprCountry { get; set; }
        public string GdprLaw { get; set; }
        public string GdprNote { get; set; }
        public string ContractLocation { get; set; }
        public string ContractStatus { get; set; }
        public Partner Partner { get; set; }
        public int? PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerAgency { get; set; }
        public string PartnerEmail { get; set; }
        public string PartnerAddress { get; set; }
        public Vendor Vendor { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public Service Service { get; set; }
        public int? ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public Process Process { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessCategory { get; set; }
        public string ProcessActivity { get; set; }
        public string ProcessNote { get; set; }
        public bool ProcessGdprRequirement { get; set; }
        public int? ProcessSortOrder { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}        
    }
}
