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
    [Authorize]
    public class VendorsController : BaseApiController
    {
        private DataContext _context { get; }
        private IMapper _mapper { get; }
        public VendorsController(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDto>>> GetVendors() 
        {
            var vendors = await _context.Vendors.ToListAsync();
            var vendorsToReturn = _mapper.Map<IEnumerable<VendorDto>>(vendors);
            return Ok(vendorsToReturn);
        }
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<VendorDto>>> SearchVendors(string searchTerm)
        {
            var vendors = await _context.Vendors.AsQueryable().ToListAsync();
            var searchList = vendors.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            var orderedList = searchList.OrderBy( x => x.Name);
            return Ok(_mapper.Map<IEnumerable<VendorDto>>(orderedList));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorDto>> GetPartner(int id)
        {
            var vendor =  await _context.Vendors.FindAsync(id);
            return _mapper.Map<VendorDto>(vendor);
        }
        [HttpPut("{id}/edit")]
        public async Task<ActionResult> UpdateVendor(VendorDto vendorDto) {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(p => p.Id == vendorDto.Id);
            if (vendor != null) return BadRequest("Vendor doesnt exist");
            if (vendor.Name == vendorDto.Name) return BadRequest("Vendor name already exists");
            vendor.Name = vendorDto.Name;
            vendor.Status = vendorDto.Status;
            vendor.VendorGroup = vendorDto.VendorGroup;
            vendor.Type = vendorDto.Type;
            vendor.Address = vendorDto.Address;
            vendor.Email = vendorDto.Email;
            vendor.LastEdited = DateTime.Now;
            try 
            {
                _context.Vendors.Update(vendor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
                return BadRequest("Failed to update vendor: " + e);
            }
            return NoContent();
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateVendor(VendorDto vendorDto) 
        {
            var serviceToCheck = await _context.Services.FirstOrDefaultAsync(p => p.Name == vendorDto.Name);
            if (serviceToCheck.Name == vendorDto.Name) return BadRequest("Vendor name already exists");
            var vendor = new Vendor {
                Name = vendorDto.Name,
                Status = vendorDto.Status,
                VendorGroup = vendorDto.VendorGroup,
                Type = vendorDto.Type,
                Address = vendorDto.Address,
                Email = vendorDto.Email
            };
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}