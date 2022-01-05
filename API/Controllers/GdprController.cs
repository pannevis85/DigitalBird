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
    public class GdprController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GdprController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("{gdprid}")]
        public async Task<ActionResult<GdprRecordDto>> GetGdprRecord(int gdprId)
        {
            var element =  await _context.GdprRecords.FirstOrDefaultAsync(x => x.Id == gdprId);
            if (element == null) return BadRequest("Gdpr record doesnt exist" + gdprId);
            return Ok(_mapper.Map<GdprRecordDto>(element));
        }
        [HttpGet("processlist/{partnerId}/{vendorId}/{serviceId}/{year}")]
        public async Task<ActionResult<IEnumerable<GdprRecordDto>>> GetGdprProcessList(int partnerId, int vendorId, int serviceId, int year)
        //public async Task<ActionResult<IEnumerable<GdprRecordDto>>> GetGdprProcessList(PartnerServiceDto partnerServiceDto)
        {
            var partner = await _context.Partners.FirstOrDefaultAsync(x => x.Id == partnerId);
            if (partner == null) return BadRequest("partner not found" + partnerId);
            var vendor = await _context.Vendors.FirstOrDefaultAsync(x => x.Id == vendorId);
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceId);
            var processList = await _context.Processes.Where(x => x.ServiceId == serviceId)
                                                    .OrderBy(x => x.SortOrder)
                                                    .ToListAsync();
            
            if (processList == null) return BadRequest("ProcessList is empty");
            
            List<GdprRecordDto> listToReturn = new List<GdprRecordDto>();
            foreach(var process in processList) {
                if (process.GdprRequirement){
                    var gdpr = await _context.GdprRecords.FirstOrDefaultAsync(x => (
                                                        (x.PartnerId == partner.Id)
                                                        && (x.VendorId == vendor.Id)
                                                        && (x.ServiceId == service.Id)
                                                        && (x.GdprRecordYear == year)
                                                        && (x.ProcessId == process.Id)
                                                        ));
                    if (gdpr != null) {
                    listToReturn.Add(_mapper.Map<GdprRecordDto>(gdpr));
                    } 
                    else
                    {
                        var record = new GdprRecordDto {
                            //Id = 0,
                            Status = "false",
                            GdprRecordYear = year,
                            GdprCountry = "country to be defined",
                            GdprLaw = "law to be defined",
                            GdprNote = "very important note",
                            ContractLocation = "contract location",
                            ContractStatus = "New",
                            PartnerId = partner.Id,
                            PartnerName = partner.Name,
                            PartnerAgency = partner.Agency,
                            PartnerEmail = partner.Email,
                            PartnerAddress = partner.Address,
                            VendorId = vendor.Id,
                            VendorName = vendor.Name,
                            ServiceId = service.Id,
                            ServiceName = service.Name,
                            ServiceDescription = service.Description,
                            ProcessId = process.Id,
                            ProcessName = process.Name,
                            ProcessCategory = process.Category,
                            ProcessActivity = process.Activity,
                            ProcessNote = process.Note,
                            ProcessGdprRequirement = process.GdprRequirement,
                            ProcessSortOrder = process.SortOrder                        
                        };
                        listToReturn.Add(record);
                    };
                }                
            }                                
            return Ok(listToReturn.OrderBy(x => x.ProcessSortOrder));
        }
        [HttpPut("edit/{gdprId}")]
        public async Task<ActionResult> UpdateGdpr(GdprRecordDto gdprDto) 
        {
            var element = await _context.GdprRecords.FirstOrDefaultAsync(x => x.Id == gdprDto.Id);
            if (element == null) return BadRequest("Gdpr record doesnt exist");
            element.Status = gdprDto.Status;
            element.GdprCountry = gdprDto.GdprCountry;
            element.GdprLaw = gdprDto.GdprLaw;
            element.GdprNote = gdprDto.GdprNote;
            element.ContractLocation = gdprDto.ContractLocation;
            element.ContractStatus = gdprDto.ContractStatus;
            element.LastEdited = DateTime.Now;

            _context.GdprRecords.Update(element);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateGdpr(GdprRecordDto gdprDto) 
        {
            gdprDto.Status = "New";
            gdprDto.ContractStatus = "New";
            _context.GdprRecords.Add(_mapper.Map<GdprRecord>(gdprDto));
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("delete/{gdprid}")]
        public async Task<ActionResult> DeleteGdpr(int gdprId) 
        {
            var element = await _context.GdprRecords.FirstOrDefaultAsync(p => p.Id == gdprId);
            if (element == null) return BadRequest("Gdpr record doesnt exist!" + gdprId + "!");
            try 
            {
                _context.GdprRecords.Remove(element);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e) {
                return BadRequest("Exception: " + e);
            }
        }
    }
}