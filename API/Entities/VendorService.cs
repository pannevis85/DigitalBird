using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VendorService
    {

        public int Id { get; set; }
        public string Status { get; set; } = "active";
        public Vendor Vendor { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public Service Service { get; set; }
        public int? ServiceId { get; set; }
        public string ServiceName { get; set; }
        public ServiceProcess ServiceProcess { get; set; }
        public int? ServiceProcessId { get; set; }
        public string ServiceProcessName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastEdited { get; set; } = DateTime.Now;
        public AppUser LastEditor { get; set; }
        public int? LastEditorId {get;set;}
    }
}
