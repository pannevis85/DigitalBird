using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        /* replaced with async task for data seeding
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        */
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try 
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                //initial tables need to be uploaded first for foreign keys
                //when seeding new data, these is phase 1
                await Seed.SeedUsers(context);
                await Seed.SeedPartners(context);
                await Seed.SeedVendors(context);
                await Seed.SeedServices(context);
                //when seeding new data, these is phase 2
                //await Seed.SeedContacts(context); //contacts were never implemented
                //await Seed.SeedProcesses(context);
                //await Seed.SeedPartnerServices(context);
                //when seeding new data, these is phase 3
                //await Seed.SeedGdpr(context);
                
            } 
            catch (Exception e) 
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "Seed migration error");
            }
            await host.RunAsync();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
