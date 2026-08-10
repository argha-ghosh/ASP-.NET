using AutoMapper;
using LABTASK2.EF;
using LABTASK2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABTASK2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        FleetDbContext db;
        IMapper mapper;
        public FuelController(FleetDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("Getlarge-fills")]
        public IActionResult GetAll()
        {
            var data = db.FuelLogs.ToList();
            var mapped = mapper.Map<List<FuelDTO>>(data);
            return Ok(mapped);
        }

        [HttpGet("Getroute-total")]
        public IActionResult Get()
        {
            var data = db.FuelLogs.ToList();
            var mapped = mapper.Map<List<FuelDTO>>(data);
            return Ok(mapped);
        }


    }
}
