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
            CreateMap<VendorDto, Vendor>();
            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();
            CreateMap<Process, ProcessDto>();
            CreateMap<ProcessDto, Process>();
            CreateMap<PartnerService, PartnerServiceDto>();
            CreateMap<PartnerServiceDto, PartnerService>();

        }
    }
}