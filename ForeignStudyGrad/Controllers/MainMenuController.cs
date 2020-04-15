using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeignStudyGrad.Models;
using ForeignStudyGrad.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignStudyGrad.Controllers
{
    public class MainMenuController : Controller
    {
        private CourseService _courseService;

        public MainMenuController(CourseService service)
        {
            _courseService = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            MMIndexViewModel mmvm = new MMIndexViewModel();
            mmvm.Courses = _courseService.ConvertDBCourseToModel(_courseService.GetUserCourses(User.Identity.Name));
            return View(mmvm);
        }
        [HttpGet]
        public IActionResult Courses()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Course(Guid courseid)
        {
            CoursViewModel cvm = new CoursViewModel();
            cvm.themes = _courseService.ConvertDBThemeToModel(_courseService.GetCourseThemes(courseid));
            return View(cvm);
        }
        [HttpGet]
        public IActionResult Dictionary()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Timetable()
        {
            return View();
        }


    }
}