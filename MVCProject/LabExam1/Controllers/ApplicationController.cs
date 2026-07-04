using LabExam1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabExam1.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Application(ApplicationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ViewBag.Message = "Application submitted successfully!";
            //return View("Success", model);
            return View(model);
        }
    }
}
