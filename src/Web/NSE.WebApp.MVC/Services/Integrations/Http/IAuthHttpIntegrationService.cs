using NSE.Shared.Models.Auths;
using NSE.WebApp.MVC.Models.Identity;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{
    public interface IAuthHttpIntegrationService
    {
        Task<UserLoginResponse> SignInAsync(UserLoginViewModel userLoginViewModel);
        Task<UserLoginResponse> RegisterAsync(UserRegisterViewModel userRegisterViewModel);
    }
}
