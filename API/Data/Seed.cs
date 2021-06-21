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
    }
}