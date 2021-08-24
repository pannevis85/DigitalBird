using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context) 
        {
            if (await context.AppUsers.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));

                await context.AppUsers.AddAsync(user);
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedPartners(DataContext context) 
        {
            if (await context.Partners.AnyAsync()) return;
            var partnerData = await System.IO.File.ReadAllTextAsync("Data/PartnerSeedData.json");
            var partners = JsonSerializer.Deserialize<List<Partner>>(partnerData);
            foreach(var partner in partners) 
            {
                context.Partners.Add(partner);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedContacts(DataContext context) 
        {
            if (await context.Contacts.AnyAsync()) return;
            var contactData = await System.IO.File.ReadAllTextAsync("Data/ContactSeedData.json");
            var contacts = JsonSerializer.Deserialize<List<Contact>>(contactData);
            foreach(var contact in contacts) 
            {
                context.Contacts.Add(contact);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedVendors(DataContext context) 
        {
            if (await context.Vendors.AnyAsync()) return;
            var vendorData = await System.IO.File.ReadAllTextAsync("Data/VendorSeedData.json");
            var vendors = JsonSerializer.Deserialize<List<Vendor>>(vendorData);
            foreach(var vendor in vendors) 
            {
                context.Vendors.Add(vendor);
            }
            await context.SaveChangesAsync();
        }

        
        public static async Task SeedServices(DataContext context) 
        {
            if (await context.Services.AnyAsync()) return;
            var serviceData = await System.IO.File.ReadAllTextAsync("Data/ServiceSeedData.json");
            var services = JsonSerializer.Deserialize<List<Service>>(serviceData);
            foreach(var service in services) 
            {
                context.Services.Add(service);
            }
            await context.SaveChangesAsync();
        }
    
        public static async Task SeedProcesses(DataContext context) 
        {
            if (await context.Processes.AnyAsync()) return;
            var ProcessesData = await System.IO.File.ReadAllTextAsync("Data/ProcessSeedData.json");
            var processes = JsonSerializer.Deserialize<List<Process>>(ProcessesData);
            foreach(var process in processes) 
            {
                context.Processes.Add(process);
            }
            await context.SaveChangesAsync();
        }
    }
}
    