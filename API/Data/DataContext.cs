using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Contact> Contacts { get; set; } 
        public DbSet<Vendor> Vendors { get; set; }        
        public DbSet<Service> Services { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<PartnerService> PartnerServices {get;set;}
        public DbSet<GdprRecord> GdprRecords { get; set; }
        
    }
}
