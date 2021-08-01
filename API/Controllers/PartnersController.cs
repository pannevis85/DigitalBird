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
            var partners = await _context.Partners.AsQueryable().ToListAsync();
            var orderedList = partners.OrderBy(p => p.Name);
            return Ok(_mapper.Map<IEnumerable<PartnerDto>>(orderedList));
        }
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<PartnerDto>>> SearchPartners(string searchTerm)
        {
            var partners = await _context.Partners.AsQueryable().ToListAsync();
            var searchList = partners.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            var orderedList = searchList.OrderBy( x => x.Name);
            return Ok(_mapper.Map<IEnumerable<PartnerDto>>(orderedList));
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerDto>> GetPartner(int id)
        {
            var partner =  await _context.Partners.FindAsync(id);
            return _mapper.Map<PartnerDto>(partner);
        }
        [HttpPut("{id}/edit")]
        public async Task<ActionResult> UpdatePartner(PartnerDto partnerDto) {
            var partner = await _context.Partners.FirstOrDefaultAsync(p => p.Id == partnerDto.Id);
            if (partner != null) return BadRequest("Partner doesnt exist");
            if (partner.Name == partnerDto.Name) return BadRequest("Partner name already exists");
            partner.Name = partnerDto.Name;
            partner.Status = partnerDto.Status;
            partner.Partner_group = partnerDto.Partner_group;
            partner.Type = partnerDto.Type;
            partner.Address = partnerDto.Address;
            partner.Email = partnerDto.Email;
            partner.Telephone = partnerDto.Telephone;
            partner.Agency = partnerDto.Agency;
            partner.LastEdited = DateTime.Now;
            try 
            {
                _context.Partners.Update(partner);
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
            var partnerCheck = await _context.Partners.FirstOrDefaultAsync(p => p.Name == partnerDto.Name);
            if (partnerCheck != null) return BadRequest("Partner doesnt exist");
            if (partnerCheck.Name == partnerDto.Name) return BadRequest("Partner name already exists");
            var partner = new Partner {
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
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}