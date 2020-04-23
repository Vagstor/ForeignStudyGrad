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
        [HttpPost]
        public IActionResult SearchCourse(AllCoursesViewModel currentModel)
        {
            AllCoursesViewModel acvm = new AllCoursesViewModel();
            acvm.courses = _courseService.ConvertDBCourseToModel(_courseService.SearchCoursesWith(currentModel.searchString));
            return View("Courses", acvm);
        }
        [HttpGet]
        public IActionResult Courses()
        {
            AllCoursesViewModel acvm = new AllCoursesViewModel();
            acvm.courses = _courseService.ConvertDBCourseToModel(_courseService.GetAllCourses());
            return View(acvm);
        }
        [HttpGet]
        public IActionResult Course(Guid courseid, string coursename)
        {
            CourseViewModel cvm = new CourseViewModel();
            cvm.courseName = coursename;
            cvm.themes = _courseService.ConvertDBThemeToModel(_courseService.GetCourseThemes(courseid));
            return View(cvm);
        }
        [HttpGet]
        public IActionResult Theme(Guid themeid, string themename)
        {
            ThemeViewModel tvm = new ThemeViewModel();
            tvm.themename = themename;
            tvm.tests = _courseService.ConvertDBTestToModel(_courseService.GetThemeTests(themeid));
            tvm.lectures = _courseService.ConvertDBLectureToModel(_courseService.GetThemeLectures(themeid));
            return View(tvm);
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