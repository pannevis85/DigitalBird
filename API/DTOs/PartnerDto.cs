using System;

namespace API.DTOs
{
    public class PartnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Partner_group { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Agency { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public int LastEditorId {get;set;}
    }
}