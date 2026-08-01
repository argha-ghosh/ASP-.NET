using API1STPRO.EF;
using API1STPRO.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1STPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolManagmentContext db;

        public StudentController(SchoolManagmentContext db)
        {
            this.db = db;
        }

        [HttpPost("AddStudent")]
        public IActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok(student);
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAll()
        {
            var students = db.Students.ToList();
            return Ok(students);
        }
    }
}
