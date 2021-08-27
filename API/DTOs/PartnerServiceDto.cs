using System;

namespace API.DTOs
{
    public class PartnerServiceDto
    {
        public int Id { get; set; }
        public string Status { get; set; }        
        public int? PartnerId {get;set;}
        public string PartnerName { get; set; }
        public int? VendorId {get;set;}
        public string VendorName { get; set; }
        public int? ServiceId {get;set;}
        public string ServiceName {get;set;}
        public int Year {get;set;}
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public int? LastEditorId {get;set;}
    }
}