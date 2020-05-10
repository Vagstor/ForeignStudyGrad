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
        private AccountService _accService;

        public MainMenuController(CourseService service, AccountService accService)
        {
            _courseService = service;
            _accService = accService;
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
            return View("AllCourses", acvm);
        }
        [HttpGet]
        public IActionResult Lecture()
        {
            return View("pdf");
        }
        [HttpGet]
        public IActionResult AllCourses()
        {
            AllCoursesViewModel acvm = new AllCoursesViewModel();
            acvm.courses = _courseService.ConvertDBCourseToModel(_courseService.GetAllCourses());
            _courseService.MatchWithSubscriptions(acvm.courses, User.Identity.Name);
            return View(acvm);
        }
        [HttpPost]
        public IActionResult SubscribeUserToCourse(Guid courseid, string username)
        {
            _courseService.SubscribeUserToCourse(courseid, username);
            return View("AllCourses");
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
        public IActionResult Theme(Guid themeid)
        {
            //ThemeViewModel tvm = new ThemeViewModel();
            //tvm.themename = themename;
            //tvm.tests = _courseService.ConvertDBTestToModel(_courseService.GetThemeTests(themeid));
            //tvm.lectures = _courseService.ConvertDBLectureToModel(_courseService.GetThemeLectures(themeid));
            return View("~/Views/TestsFirstCourse/Test1Theme.cshtml");
        }
        [HttpGet]
        public IActionResult Dictionary()
        {
            DictionaryViewModel dvm = new DictionaryViewModel()
            {
                Pairs = _courseService.ConvertDBDictionaryPairsToModel(_courseService.GetUserDictionary(User.Identity.Name))
            };
            return View(dvm);
        }
        [HttpGet]
        public IActionResult Timetable()
        {
            return View();
        }


    }
}