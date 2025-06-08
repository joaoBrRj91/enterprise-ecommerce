using NSE.Shared.Models.Auth;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{
    public interface IAuthHttpIntegrationService
    {
        Task<UserLoginResponse> SignInAsync(UserLoginViewModel userLoginViewModel);
        Task<UserLoginResponse> RegisterAsync(UserRegisterViewModel userRegisterViewModel);
    }
}
