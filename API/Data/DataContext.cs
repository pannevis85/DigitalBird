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
        //public DbSet<ProcessType> ProcessTypes { get; set; }
        //public DbSet<Process> Processes { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<VendorService> VendorServices { get; set; }
        //public DbSet<GdprRecord> GdprRecords { get; set; }
        
    }
}
