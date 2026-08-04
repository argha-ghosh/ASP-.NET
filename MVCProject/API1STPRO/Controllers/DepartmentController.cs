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
        [HttpPost("AddDepartment")]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return Ok(department);
        }

        //GET https://localhost:7211/api/Department/GetAllDepartments
        [HttpGet("GetAllDepartments")]
        public IActionResult GetAll()
        {
            var departments = db.Departments.ToList();
            return Ok(departments);
        }

        //GET https://localhost:7211/api/Department/GetDepartmentById/{id}  
        [HttpGet("GetDepartmentById/{id}")]
        public IActionResult GetById(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        //DELETE https://localhost:7211/api/Department/DeleteDepartment/{id}
        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult Delete(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();
            return Ok(department);
        }

        //PUT https://localhost:7211/api/Department/UpdateDepartment/{id}
        [HttpPut("UpdateDepartment/{id}")]
        public IActionResult Update(int id, Department department)
        {
            var existingDepartment = db.Departments.Find(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.DeptName = department.DeptName;
            existingDepartment.DeptLocation = department.DeptLocation;

            db.SaveChanges();
            return Ok(existingDepartment);
        }


        // --------------------------BY USING MODEL----------------------------- 


        //POST https://localhost:7211/api/Department/AddDepartmentWithDto
        //Using dto class for department creation
        //[HttpPost("AddDepartmentWithDto")]
        //public IActionResult Create(DeptDTO departmentDto)
        //{
        //    var department = new Department
        //    {
        //        DeptName = departmentDto.DeptName,
        //        DeptLocation = departmentDto.DeptLocation
        //    };
        //    db.Departments.Add(department);
        //    db.SaveChanges();
        //    return Ok(department);
        //}

        //Using dto class for department retrieval
        //GET https://localhost:7211/api/Department/GetAllDepartmentsWithDto
        //[HttpGet("GetAllDepartmentsWithDto")]
        //public IActionResult GetAll()
        //{
        //    var departments = db.Departments.Select(d => new DeptDTO
        //    {
        //        DeptId = d.DeptId,
        //        DeptName = d.DeptName,
        //        DeptLocation = d.DeptLocation
        //    }).ToList();
        //    return Ok(departments);
        //}
    }
}
