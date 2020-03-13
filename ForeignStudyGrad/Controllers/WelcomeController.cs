using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForeignStudyGrad.Models;
using ForeignStudyGrad.Services;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading;

namespace ForeignStudyGrad.Controllers
{
    public class WelcomeController : Controller
    {
        private SiteService _service;
        public WelcomeController(SiteService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel currentUser)
        {

            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }

            else

            if (!_service.CheckIfLoginVacant(currentUser.Login))
            {
                ModelState.AddModelError("Login", "Такой логин уже существует");
            }

            else

            if (!_service.CheckIfEmailVacant(currentUser.Email))
            {
                ModelState.AddModelError("Email", "Такой Email уже существует");
            }

            else

            {
                _service.AddNewUser(currentUser.Login, currentUser.Password, currentUser.Email);
                return RedirectToAction("Login", "Welcome");
            }

            return View(currentUser);
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Welcome");
        }
        [HttpPost]
        public IActionResult Login(LoginModel currentUser)
        {
            var user = _service.GetByLogin(currentUser.Login);

            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }
            else if (user == null)
            {
                ModelState.AddModelError("Login", "Неправильно введено имя пользователя");
            }
            else if (user.Password != currentUser.Password)
            {
                ModelState.AddModelError("Password", "Неправильно введен пароль");
            }
            else
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim("userId", Convert.ToString(user.Id))
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("SitesList", "WebSites");
            }
            return View(currentUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
