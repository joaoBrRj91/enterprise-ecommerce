﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services.Integrations.Http;

namespace NSE.WebApp.MVC.Controllers
{
    public class AuthController(IAuthHttpIntegrationService authHttpIntegrationService) : Controller
    {
        [HttpGet("new-account")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
        {
            if (!ModelState.IsValid) return View(userRegister);
            // Here you would typically call your API to register the user
            // For example:
            // var response = await _apiService.RegisterUserAsync(userRegister);
            // if (!response.IsSuccess) return View(userRegister);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("sign-in")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);
            // Here you would typically call your API to log in the user
            // For example:
            // var response = await _apiService.LoginUserAsync(userLogin);
            // if (!response.IsSuccess) return View(userLogin);
            return RedirectToAction("Index", "Home");
        }
    }
}
