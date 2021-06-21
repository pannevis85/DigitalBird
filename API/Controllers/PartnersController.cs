using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
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

    }
}