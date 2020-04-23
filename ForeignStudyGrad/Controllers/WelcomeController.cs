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
        private AccountService _service;
        public WelcomeController(AccountService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel currentUser)
        {
            //регистрация пользователя. Первое условие проверяет, валидны ли значения на форме, 2-3 - свободны ли Login и Email, если всё в порядке, 
            //происходит передача данных в бд

            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }

            else if (!_service.CheckIfLoginVacant(currentUser.user.Login))
            {
                ModelState.AddModelError("Login", "Такой логин уже существует");
            }

            else if (!_service.CheckIfEmailVacant(currentUser.user.Email))
            {
                ModelState.AddModelError("Email", "Такой Email уже существует");
            }

            else
            {
                _service.AddNewUser(currentUser.user.Login, currentUser.user.Password, currentUser.user.Email, currentUser.user.Role);
                return RedirectToAction("Login", "Welcome");
            }

            return View(currentUser);
        }

        public IActionResult Logout()
        {
            //выход из учетной записи и перенаправление на страницу входа
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Welcome");
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel currentUser)
        {
            //проверка данных на странице логина 
            bool userCheck = _service.CheckLogin(currentUser);

            //если модель не валидна, возвращается вью с ошибками
            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }

            //если пользователей с такими параметрами нет в бд
            else if (!userCheck)
            {
                ModelState.AddModelError("Login", "Неправильно введены данные");
            }
            
            //если данные верны, создаём новую Identity для пользователя и перенаправляем на главное меню
            else
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, currentUser.user.Login),
                        //new Claim("userId", Convert.ToString(user.UserId))
                        //new Claim(ClaimTypes.Role, user.UserRole)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return MMRedirect();

                //if (User.HasClaim("Role", "Преподаватель"))
                //return RedirectToAction("TeacherMM", "MainMenu");
                //else return RedirectToAction("StudentMM", "MainMenu");
            }
            return View(currentUser);
        }

        [HttpPost]
        public IActionResult MMRedirect()
        {
                return RedirectToAction("Index", "MainMenu");
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
