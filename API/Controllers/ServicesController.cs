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
    public class ServicesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ServicesController(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices() 
        {
            var list = await _context.Services
                            .OrderBy(p => p.Name)
                            .ToListAsync();
            var mappedList = _mapper.Map<IEnumerable<ServiceDto>>(list);
            return Ok(mappedList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            var service =  await _context.Services.FindAsync(id);
            return _mapper.Map<ServiceDto>(service);
        }
        [HttpPut("{id}/edit")]
        public async Task<ActionResult> UpdateService(ServiceDto serviceDto) 
        {
            var check = await _context.Services.AnyAsync(p => p.Name == serviceDto.Name);
            if (!check) return BadRequest("Service doesnt exists");
            var service = await _context.Services.FirstOrDefaultAsync(p => p.Id == serviceDto.Id);
            // if (service == null) return BadRequest("Service doesnt exist");
            service.Name = serviceDto.Name;
            service.Status = serviceDto.Status;
            service.Description = serviceDto.Description;
            service.LastEdited = DateTime.Now;
            try 
            {
                _context.Services.Update(service);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
                return BadRequest("Failed to update service: " + e);
            }
            return NoContent();
        }
        
        [HttpPost("create")]
        public async Task<ActionResult> CreateService(ServiceDto serviceDto) 
        {
            var check = await _context.Services.AnyAsync(p => p.Name == serviceDto.Name);
            if (check) return BadRequest("Service name already exists");
            var service = new Service {
                Name = serviceDto.Name,
                Status = serviceDto.Status,
                Description = serviceDto.Description,
                LastEdited = DateTime.Now
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}