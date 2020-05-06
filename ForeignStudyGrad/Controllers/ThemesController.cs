using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeignStudyGrad.Models;
using ForeignStudyGrad.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignStudyGrad.Controllers
{
    public class ThemesController : Controller
    {

        private ThemeService _themeService;

        public ThemesController(ThemeService service)
        {
            _themeService = service;
        }
        [HttpGet]
        public IActionResult ShowTheme(Guid themeid)
        {
            ThemeViewModel vm = _themeService.GetThemeInfoById(themeid);
            return View(vm.Link,vm);
        }
    }
}