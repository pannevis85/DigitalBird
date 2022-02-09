using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using API.Helpers;
using System;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            //creating web tokens
            services.AddScoped<ITokenService, TokenService>();
            //add UserRepository
            
            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            //Add datacontext
            services.AddDbContext<API.Data.DataContext>(option => option.UseSqlServer(config.GetConnectionString("Live")));
            //services.AddDbContext<API.Data.DataContext>(option => option.UseSqlServer(config.GetConnectionString("Humse")));
            //services.AddDbContext<API.Data.DataContext>(option => option.UseSqlServer(config.GetConnectionString("SqlExpress")));

            return services;
        }   
    }
}