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
    }
}