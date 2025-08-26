using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.Shared.Models.Auths;
using NSE.Shared.Models.Common;
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

            return await CreateResultByResponseIntegration(response, userRegister);
        }

        [HttpGet("sign-in")]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(userLogin);

            var response = await authHttpIntegrationService.SignInAsync(userLogin);

            return await CreateResultByResponseIntegration(response, userLogin, returnUrl);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        #region Private Aux Methods
        private async Task GeneratedLoginAsync(UserLoginResponse userLoginResponse)
        {
            var (claimsIdentity, authenticationProperties) = autenticationJwtService
                .BuildTokenPrincipalInformations(userLoginResponse, authenticationType: AuthType.Cookie);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authenticationProperties);
        }

        private async Task<ActionResult> CreateResultByResponseIntegration(ResponseResult response, object requestData, string? returnUrl = null)
        {
            if (HasErrorsInIntegration(response)) return View(requestData);

            await GeneratedLoginAsync((response.Data as UserLoginResponse)!);

            if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            return LocalRedirect(returnUrl);
        }
        #endregion
    }
}
