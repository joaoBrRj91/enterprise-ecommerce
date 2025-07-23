using NSE.Shared.Models.Auths;
using NSE.Shared.Models.Common.Validations;
using NSE.WebApp.MVC.Models.Identity;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{
    public interface IAuthHttpIntegrationService
    {
        Task<ResponseResult> SignInAsync(UserLoginViewModel userLoginViewModel);
        Task<ResponseResult> RegisterAsync(UserRegisterViewModel userRegisterViewModel);
    }
}
