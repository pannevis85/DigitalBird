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
    public class ProcessController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProcessController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessDto>>> GetProcess()
        {
            var list = await _context.Processes
                            .OrderBy(p => p.Name)
                            .ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProcessDto>>(list));
        }

        [HttpGet("{serviceid}")]
        public async Task<ActionResult<IEnumerable<ProcessDto>>> GetProcess(int serviceId)
        {
            var list =  await _context.Processes
                            .Where(p => p.ServiceId == serviceId)
                            .OrderBy(p => p.SortOrder)
                            .ToListAsync();
            if (!list.Any()) return BadRequest("Process list is empty");
            return Ok(_mapper.Map<IEnumerable<ProcessDto>>(list));
        }
        [HttpPut("{serviceid}/edit")]
        public async Task<ActionResult> UpdateProcess(ProcessDto processDto) 
        {
            var process = await _context.Processes.FirstOrDefaultAsync(p => p.Id == processDto.Id);
            if (process == null) return BadRequest("Process doesnt exist");
            process.Name = processDto.Name;
            process.Status = processDto.Status;
            process.ServiceId = processDto.ServiceId;
            process.ServiceName = processDto.ServiceName;
            process.Category = processDto.Category;
            process.Activity = processDto.Activity;
            process.Note = processDto.Note;
            process.GdprRequirement = processDto.GdprRequirement;
            process.SortOrder = processDto.SortOrder;
            process.LastEdited = DateTime.Now;
            try 
            {
                _context.Processes.Update(process);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) {
                return BadRequest("Failed to update Process: " + e);
            }
            return NoContent();
        }

        [HttpPost("{serviceid}/create")]
        public async Task<ActionResult> CreateProcess(ProcessDto processDto) 
        {
            var process = new Process {
                Name = processDto.Name,
                Status = processDto.Status,
                ServiceId = processDto.ServiceId,
                ServiceName = processDto.ServiceName,
                Category = processDto.Category,
                Activity = processDto.Activity,
                Note = processDto.Note,
                GdprRequirement = processDto.GdprRequirement,
                SortOrder = processDto.SortOrder,
                LastEdited = DateTime.Now,
                Created = DateTime.Now
            };
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("delete/{processid}")]
        public async Task<ActionResult> DeleteProcess(int processId) 
        {
            var element = await _context.Processes.FirstOrDefaultAsync(p => p.Id == processId);
            if (element == null) return BadRequest("Process doesnt exist!" + processId + "!");
            try 
            {
                _context.Processes.Remove(element);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e) {
                return BadRequest("Exception: " + e);
            }
        }
    }
}