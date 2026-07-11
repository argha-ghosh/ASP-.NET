using Microsoft.AspNetCore.Mvc;
using MVCProject.EF;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        SchoolManagmentContext db;
        public StudentController(SchoolManagmentContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.TitleIndex = "Students Index";
            ViewBag.MessageIndex = "Welcome to the Student Index page!";
            return View();
        }
        public IActionResult Details(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }
        public IActionResult About()
        {
            return Content("This is about page!");
            //return View();
        }

        //Log in form
        [HttpGet]
        public IActionResult  Login()
        {
            ViewBag.TitleLogin = "Login as a Student";
            ViewBag.MessageLogin = "Please enter your login credentials.";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Uname, string Pass)
        {
            ViewBag.TitleLogin = "Login as a Student";
            if (Uname == "Argha" && Pass == "1234")
            {
                ViewBag.LoginMessage = "Login successful!";
                //return View("LoginSuccess");
            }
            else
            {
                ViewBag.LoginMessage = "Invalid username or password. Please try again.";
            }
            return View();
        }

        //Registration form
        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.TitleRegistraion = "Welcome to the registration page";
            ViewBag.MessageRegistration = "Please fill out the form to register as a student.";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(StudentRegisterModel model)
        {
            ViewBag.TitleRegistraion = "Welcome to the registration page";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.StudentId == "STU001")
            {
                ModelState.AddModelError("StudentId", "Student ID already exists. Please choose a different ID.");
                return View(model);
            }
            ViewBag.RegistrationMessage = $"Registration successful! Welcome, {model.Name}.";
            return View("Success", model);
        }


        //Student List
        public IActionResult StudentList()
        {
            ViewBag.TitleStudentList = "Student List";
            ViewData["SubTitleStudentList"] = "Enrolled Student to this Semester.";

            var students = new List<string>
            {
                "Alice Johnson",
                "Bob Smith",
                "Charlie Brown",
                "Diana Prince",
                "Ethan Hunt"
            };
            return View(students);
        }
    }
}
