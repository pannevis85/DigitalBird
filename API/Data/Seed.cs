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

            var jsonData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var list = JsonSerializer.Deserialize<List<AppUser>>(jsonData);
            if (list == null) return;
            foreach (var user in list)
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
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/PartnerSeedData.json");
            var list = JsonSerializer.Deserialize<List<Partner>>(jsonData);
            foreach(var partner in list) 
            {
                context.Partners.Add(partner);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedContacts(DataContext context) 
        {
            if (await context.Contacts.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/ContactSeedData.json");
            var list = JsonSerializer.Deserialize<List<Contact>>(jsonData);
            foreach(var contact in list) 
            {
                context.Contacts.Add(contact);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedVendors(DataContext context) 
        {
            if (await context.Vendors.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/VendorSeedData.json");
            var list = JsonSerializer.Deserialize<List<Vendor>>(jsonData);
            foreach(var vendor in list) 
            {
                context.Vendors.Add(vendor);
            }
            await context.SaveChangesAsync();
        }

        
        public static async Task SeedServices(DataContext context) 
        {
            if (await context.Services.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/ServiceSeedData.json");
            var list = JsonSerializer.Deserialize<List<Service>>(jsonData);
            foreach(var service in list) 
            {
                context.Services.Add(service);
            }
            await context.SaveChangesAsync();
        }
    
        public static async Task SeedProcesses(DataContext context) 
        {
            if (await context.Processes.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/ProcessSeedData.json");
            var list = JsonSerializer.Deserialize<List<Process>>(jsonData);
            foreach(var process in list) 
            {
                context.Processes.Add(process);
            }
            await context.SaveChangesAsync();
        }
        

        public static async Task SeedPartnerServices(DataContext context) 
        {
            if (await context.PartnerServices.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/PartnerServiceSeedData.json");
            var list = JsonSerializer.Deserialize<List<PartnerService>>(jsonData);
            foreach(var element in list) 
            {
                context.PartnerServices.Add(element);
            }
            await context.SaveChangesAsync();
        }
                public static async Task SeedGdpr(DataContext context) 
        {
            if (await context.GdprRecords.AnyAsync()) return;
            var jsonData = await System.IO.File.ReadAllTextAsync("Data/GdprSeedData.json");
            var list = JsonSerializer.Deserialize<List<GdprRecord>>(jsonData);
            foreach(var element in list) 
            {
                context.GdprRecords.Add(element);
            }
            await context.SaveChangesAsync();
        }
    }
}
    