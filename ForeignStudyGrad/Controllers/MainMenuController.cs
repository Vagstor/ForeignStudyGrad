using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForeignStudyGrad.Controllers
{
    public class MainMenuController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Courses()
        {
            return View();
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