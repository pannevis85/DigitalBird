namespace API.Entities
{
    public class PartnerService
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Year {get;set;}
        public string Note { get; set; }
        public Partner Partner {get;set;}
        public int? PartnerId {get;set;}
        public VendorService VendorService {get;set;}
        public int? VendorServiceId { get; set; }
    }
}