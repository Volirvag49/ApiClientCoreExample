using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.BLL.Infrastructure;
using ApiClientCoreExample.BLL.Interfaces;
using ApiClientCoreExample.WEB.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiClientCoreExample.WEB.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginStatus = await userService.Login(model.Login, model.Password);
                    
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");

                }
                catch (BusinessLogicException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);

                }
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id),
                new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)});
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDTO user = Mapper.Map<RegisterModel, UserDTO>(model);
                    await userService.Register(user);
                    return RedirectToAction("Login");
                }
                catch (BusinessLogicException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);

                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}