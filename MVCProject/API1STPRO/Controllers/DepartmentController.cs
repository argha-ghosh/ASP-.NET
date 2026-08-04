using API1STPRO.EF;
using API1STPRO.EF.Tables;
using API1STPRO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1STPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SchoolManagmentContext db;

        public DepartmentController(SchoolManagmentContext db)
        {
            this.db = db;
        }

        //POST https://localhost:7211/api/Department/AddDepartment
        //[HttpPost("AddDepartment")]
        //public IActionResult Create(Department department)
        //{
        //    db.Departments.Add(department);
        //    db.SaveChanges();
        //    return Ok(department);
        //}

        //POST https://localhost:7211/api/Department/AddDepartmentWithDto
        //Using dto class for department creation
        [HttpPost("AddDepartmentWithDto")]
        public IActionResult Create(DeptDTO departmentDto)
        {
            var department = new Department
            {
                DeptName = departmentDto.DeptName,
                DeptLocation = departmentDto.DeptLocation
            };
            db.Departments.Add(department);
            db.SaveChanges();
            return Ok(department);
        }

        //GET https://localhost:7211/api/Department/GetAllDepartments
        //[HttpGet("GetAllDepartments")]
        //public IActionResult GetAll()
        //{
        //    var departments = db.Departments.ToList();
        //    return Ok(departments);
        //}

        //Using dto class for department retrieval
        //GET https://localhost:7211/api/Department/GetAllDepartmentsWithDto
        [HttpGet("GetAllDepartmentsWithDto")]
        public IActionResult GetAll()
        {
            var departments = db.Departments.Select(d => new DeptDTO
            {
                DeptId = d.DeptId,
                DeptName = d.DeptName,
                DeptLocation = d.DeptLocation
            }).ToList();
            return Ok(departments);
        }
    }
}
