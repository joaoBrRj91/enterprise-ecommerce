using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.Shared.Models.Auths;
using NSE.Shared.Services.Auths.Jwt;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services.Integrations.Http;

namespace NSE.WebApp.MVC.Controllers
{
    public class AuthController(
        IAuthHttpIntegrationService authHttpIntegrationService,
        IAutenticationJwtService autenticationJwtService) : MainController
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

            var response = await authHttpIntegrationService.RegisterAsync(userRegister);

            if (HasErrorsInIntegration(response)) return View(userRegister);

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

            var response = await authHttpIntegrationService.SignInAsync(userLogin);

            if (HasErrorsInIntegration(response)) return View(userLogin);

            return RedirectToAction("Index", "Home");
        }

        private async Task GeneratedLoginAsync(UserLoginResponse userLoginResponse)
        {
            var (claimsIdentity, authenticationProperties) = autenticationJwtService
                .BuildTokenPrincipalInformations(userLoginResponse, authenticationType: AuthType.Cookie);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authenticationProperties);
        }
    }
}
