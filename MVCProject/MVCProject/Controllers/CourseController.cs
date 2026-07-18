using Microsoft.AspNetCore.Mvc;
using MVCProject.EF;

namespace MVCProject.Controllers
{
    [Route("Courses")]
    public class CourseController : Controller
    {
        SchoolManagmentContext db;
        public CourseController(SchoolManagmentContext db)
        {
            this.db = db;
        }

        //Accessible at: /Courses
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.TitleCourse = "All Courses";
            return View();
        }

        //Accessible at: /Courses/Details/5
        [Route("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        //Accessible at: /Courses/search?keyword=CourseName
        [Route("search")]
        public IActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }
    }
}
