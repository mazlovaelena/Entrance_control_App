using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrance_Control_App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Entrance_Control_App.Controllers
{
    public class LoginController : Controller
    {
        private Entrance_ControlContext _context;
        public LoginController(Entrance_ControlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Authorisation(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return View();
            }

            model.User = _context.Users.ToList();

            await Authenticate(user);
            return RedirectToAction("Entrance", "Home");

        }
        public IActionResult Authorisation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(LoginRegViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_context.Users.Any(x => x.Email == model.Email))
            {
                return View();
            }

            var user = new User
            {

                Email = model.Email,
                Password = model.Password,
                UserRole = UserRole.User,

            };

            _context.Users.Add(user);
            _context.SaveChanges();

            await Authenticate(user);
            return RedirectToAction("Entrance", "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim("IdUser", user.IdUser.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
