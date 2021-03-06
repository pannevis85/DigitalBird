using System;

namespace API.Entities
{
    public class PartnerService
    {
        public int Id { get; set; }
        public string Status { get; set; }        
        public Partner Partner {get;set;}
        public int? PartnerId {get;set;}
        public string PartnerName { get; set; }
        public Vendor Vendor {get;set;}
        public int? VendorId {get;set;}
        public string VendorName { get; set; }
        public Service Service {get;set;}
        public int? ServiceId {get;set;}
        public string ServiceName {get;set;}
        public int Year {get;set;}
        public string Note { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}