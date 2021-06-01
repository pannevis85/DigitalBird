using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            //creating web tokens
            services.AddScoped<ITokenService, TokenService>();
            //Add datacontext
            //services.AddDbContext<API.Data.DataContext>(option => option.UseSqlServer(config.GetConnectionString("Humse")));
            services.AddDbContext<API.Data.DataContext>(option => option.UseSqlServer(config.GetConnectionString("SqlExpress")));
            //services.AddDbContext<API.Data.DataContext>(option => option.UseSqlite(config.GetConnectionString("SqLite")));

            return services;
        }   
    }
}