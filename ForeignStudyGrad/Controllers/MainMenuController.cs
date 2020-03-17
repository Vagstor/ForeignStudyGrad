using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForeignStudyGrad.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult TeacherMM()
        {
            return View();
        }
        public IActionResult StudentMM()
        {
            return View();
        }
    }
}