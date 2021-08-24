using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Partner, PartnerDto>();
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<UserPasswordUpdateDto, AppUser>();
            CreateMap<Vendor, VendorDto>();
            CreateMap<Service, ServiceDto>();
            CreateMap<Process, ProcessDto>();

        }
    }
}