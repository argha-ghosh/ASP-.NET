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

        //POST https://localhost:7211/api/Student/AddStudent
        [HttpPost("AddStudent")]
        public IActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok(student);
        }

        //GET https://localhost:7211/api/Student/GetAllStudents
        [HttpGet("GetAllStudents")]
        public IActionResult GetAll()
        {
            var students = db.Students.ToList();
            return Ok(students);
        }

        //GET https://localhost:7211/api/Student/GetStudentById/1
        [HttpGet("GetStudentById/{id}")]
        public IActionResult Get(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //PUT https://localhost:7211/api/Student/UpdateStudent/1
        [HttpPut("UpdateStudent/{id}")]
        public IActionResult Put(Student student)
        {
            var existingStudent = db.Students.Find(student.StudentId);
            if (existingStudent == null)
            {
                return NotFound();
            }
            else
            {
                existingStudent.StudenrtName = student.StudenrtName;
                existingStudent.DeptName = student.DeptName;
                existingStudent.BloodGroup = student.BloodGroup;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Cgpa = student.Cgpa;
                db.SaveChanges();
                return Ok(existingStudent);
            }
        }

        //DELETE https://localhost:7211/api/Student/DeleteStudent/1
        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }
    }
}
