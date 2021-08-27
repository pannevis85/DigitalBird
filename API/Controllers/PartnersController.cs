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
    public class PartnersController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PartnersController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerDto>>> GetPartners()
        {
            var list = await _context.Partners.AsQueryable()
                                .OrderBy(p => p.Name)
                                .ToListAsync();            
            return Ok(_mapper.Map<IEnumerable<PartnerDto>>(list));
        }
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<PartnerDto>>> SearchPartners(string searchTerm)
        {
            var list = await _context.Partners
                                        .Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) 
                                        || x.Partner_group.ToLower().Contains(searchTerm.ToLower()))
                                        .OrderBy( x => x.Name)
                                        .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PartnerDto>>(list));
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerDto>> GetPartner(int id)
        {
            var partner =  await _context.Partners.FindAsync(id);
            return _mapper.Map<PartnerDto>(partner);
        }
        [HttpPut("{id}/edit")]
        public async Task<ActionResult> UpdatePartner(PartnerDto partnerDto) {
            var element = await _context.Partners.FirstOrDefaultAsync(p => p.Id == partnerDto.Id);
            if (element == null) return BadRequest("Partner doesnt exist");
            element.Name = partnerDto.Name;
            element.Status = partnerDto.Status;
            element.Partner_group = partnerDto.Partner_group;
            element.Type = partnerDto.Type;
            element.Address = partnerDto.Address;
            element.Email = partnerDto.Email;
            element.Telephone = partnerDto.Telephone;
            element.Agency = partnerDto.Agency;
            element.LastEdited = DateTime.Now;
            try 
            {
                _context.Partners.Update(element);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
                return BadRequest("Failed to update partner: " + e);
            }
            return NoContent();
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreatePartner(PartnerDto partnerDto) 
        {
            var exists = await _context.Partners.AnyAsync(p => p.Name == partnerDto.Name);
            if (exists) return BadRequest("Partner name already exists");
            var element = new Partner {
                Name = partnerDto.Name,
                Status = partnerDto.Status,
                Partner_group = partnerDto.Partner_group,
                Type = partnerDto.Type,
                Address = partnerDto.Address,
                Email = partnerDto.Email,
                Telephone = partnerDto.Telephone,
                Agency = partnerDto.Agency,
                LastEdited = DateTime.Now                
            };
            _context.Partners.Add(element);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}