using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentServices services;
        public DepartmentController(DepartmentServices services)
        {
            this.services = services;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var data = services.All();
            return Ok(data);
        }
    }
}
