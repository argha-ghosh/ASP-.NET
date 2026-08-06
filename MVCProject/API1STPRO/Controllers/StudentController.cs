using API1STPRO.EF;
using API1STPRO.EF.Tables;
using API1STPRO.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API1STPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        SchoolManagmentContext db;
        IMapper mapper;
        public StudentController(SchoolManagmentContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost("AddStudent")]
        public IActionResult Create(StudentModel SM)
        {
            var data = mapper.Map<Student>(SM);
            db.Students.Add(data);
            db.SaveChanges();
            return Ok(data);
        }

        [HttpPost("UpdateStudent")]
        public IActionResult Update(StudentModel SM)
        {
            var data = db.Students.Find(SM.StudentId);
            //var mapped = mapper.Map<Student>(SM);
            //db.Entry(data).CurrentValues.SetValues(mapped);
            data.StudenrtName = SM.StudenrtName;
            data.DateOfBirth = SM.DateOfBirth;
            data.BloodGroup = SM.BloodGroup;

            db.SaveChanges();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Students
                         .Include(s => s.Dept)
                         .SingleOrDefault(s => s.StudentId == id);

            var mapped = mapper.Map<StudentInfoModel>(data);
            return Ok(mapped);
        }
    }
    //{
    //    private readonly SchoolManagmentContext db;

    //    public StudentController(SchoolManagmentContext db)
    //    {
    //        this.db = db;
    //    }

    //    //POST https://localhost:7211/api/Student/AddStudent
    //    [HttpPost("AddStudent")]
    //    public IActionResult Create(Student student)
    //    {
    //        db.Students.Add(student);
    //        db.SaveChanges();
    //        return Ok(student);
    //    }

    //    //GET https://localhost:7211/api/Student/GetAllStudents
    //    [HttpGet("GetAllStudents")]
    //    public IActionResult GetAll()
    //    {
    //        var students = db.Students.ToList();
    //        return Ok(students);
    //    }

    //    //GET https://localhost:7211/api/Student/GetStudentById/1
    //    [HttpGet("GetStudentById/{id}")]
    //    public IActionResult Get(int id)
    //    {
    //        var student = db.Students.Find(id);
    //        if (student == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(student);
    //    }

    //    //PUT https://localhost:7211/api/Student/UpdateStudent/1
    //    [HttpPut("UpdateStudent/{id}")]
    //    public IActionResult Put(Student student)
    //    {
    //        var existingStudent = db.Students.Find(student.StudentId);
    //        if (existingStudent == null)
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            existingStudent.StudenrtName = student.StudenrtName;
    //            existingStudent.DeptName = student.DeptName;
    //            existingStudent.BloodGroup = student.BloodGroup;
    //            existingStudent.DateOfBirth = student.DateOfBirth;
    //            existingStudent.Cgpa = student.Cgpa;
    //            db.SaveChanges();
    //            return Ok(existingStudent);
    //        }
    //    }

    //    //DELETE https://localhost:7211/api/Student/DeleteStudent/1
    //    [HttpDelete("DeleteStudent/{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        var student = db.Students.Find(id);
    //        if (student == null)
    //        {
    //            return NotFound();
    //        }
    //        db.Students.Remove(student);
    //        db.SaveChanges();
    //        return Ok(student);
    //    }
    //}
}
