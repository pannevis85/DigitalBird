using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[Authorize]
    public class PartnerServiceController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PartnerServiceController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerServiceDto>>> GetPartnerServicesAll(int partnerId)
        {
            var list = await _context.PartnerServices
                            .OrderBy(p => p.VendorName)
                            .ThenBy(p => p.ServiceName)
                            .ThenBy(p => p.Year)
                            .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PartnerServiceDto>>(list));
        }
        [HttpGet("{partnerid}")]
        public async Task<ActionResult<IEnumerable<PartnerServiceDto>>> GetPartnerServices(int partnerId)
        {
            var list = await _context.PartnerServices
                            .Where(p => p.PartnerId == partnerId)
                            .OrderBy(p => p.VendorName)
                            .ThenBy(p => p.ServiceName)
                            .ThenBy(p => p.Year)
                            .ToListAsync();
            //if (!list.Any()) return BadRequest("Partner has no services");
            return Ok(_mapper.Map<IEnumerable<PartnerServiceDto>>(list));
        }
        [HttpPut("{id}/edit")]
        public async Task<ActionResult> UpdatePartnerService(PartnerServiceDto partnerServiceDto) {
            var element = await _context.PartnerServices.FirstOrDefaultAsync(p => p.Id == partnerServiceDto.Id);
            if (element == null) return BadRequest("Partner service doesnt exist");
            var check = await _context.PartnerServices.AnyAsync(x => 
                                    (x.Id != partnerServiceDto.Id)
                                    && (x.PartnerId == partnerServiceDto.PartnerId)
                                    && (x.VendorName == partnerServiceDto.VendorName)
                                    && (x.ServiceName == partnerServiceDto.ServiceName)
                                    && (x.Year == partnerServiceDto.Year)                                    
                                    );
            if (check) return BadRequest("Partner service already exists");
            var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Name == partnerServiceDto.VendorName);
            var service = await _context.Services.FirstOrDefaultAsync(v => v.Name == partnerServiceDto.ServiceName);
            
            element.Status = partnerServiceDto.Status;
            element.PartnerId = partnerServiceDto.PartnerId;
            element.PartnerName = partnerServiceDto.PartnerName;
            element.VendorId = vendor.Id;
            element.VendorName = vendor.Name;
            element.ServiceId = service.Id;
            element.ServiceName = service.Name;
            element.Year = partnerServiceDto.Year;
            element.Note = partnerServiceDto.Note;
            element.LastEdited = DateTime.Now;
            try 
            {
                _context.PartnerServices.Update(element);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
                return BadRequest("Failed to update partner service: " + e);
            }
            return NoContent();
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreatePartnerService(PartnerServiceDto partnerServiceDto) 
        {
            var check = await _context.PartnerServices.AnyAsync(x => 
                                    //only vendor name and service name are collected in the dialog, search by name
                                    (x.PartnerId == partnerServiceDto.PartnerId)
                                    && (x.VendorName == partnerServiceDto.VendorName)
                                    && (x.ServiceName == partnerServiceDto.ServiceName)
                                    && (x.Year == partnerServiceDto.Year)
                                    );
            if (check) return BadRequest("Partner service already exists");
            var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Name == partnerServiceDto.VendorName);
            var service = await _context.Services.FirstOrDefaultAsync(v => v.Name == partnerServiceDto.ServiceName);
            var element = new PartnerService
            {
                Status = partnerServiceDto.Status,
                PartnerId = partnerServiceDto.PartnerId,
                PartnerName = partnerServiceDto.PartnerName,
                VendorId = vendor.Id,
                VendorName = vendor.Name,
                ServiceId = service.Id,
                ServiceName = service.Name,
                Year = partnerServiceDto.Year,
                Note = partnerServiceDto.Note,
                LastEdited = DateTime.Now,
                Created = DateTime.Now       
            };
            _context.PartnerServices.Add(element);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("delete/{partnerServiceId}")]
        public async Task<ActionResult> DeletePartnerService(int partnerServiceId) 
        {
            var element = await _context.PartnerServices.FirstOrDefaultAsync(p => p.Id == partnerServiceId);
            if (element == null) return BadRequest("Partner service doesnt exist!" + partnerServiceId + "!");
            try 
            {
                _context.PartnerServices.Remove(element);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e) {
                return BadRequest("Exception: " + e);
            }
        }
    }
}