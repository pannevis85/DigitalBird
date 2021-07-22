using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
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
            var partners = await _context.Partners.ToListAsync();
            var partnersToReturn = _mapper.Map<IEnumerable<PartnerDto>>(partners);
            return Ok(partnersToReturn);
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
            if (partner == null) return BadRequest("Not found in context");
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
                return BadRequest("Failed to update user: " + e);
            }
            return NoContent();
        }

    }
}