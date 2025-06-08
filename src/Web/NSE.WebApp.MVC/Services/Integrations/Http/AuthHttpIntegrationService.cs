using NSE.Shared.Models.Auth;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{
    public class AuthHttpIntegrationService : IAuthHttpIntegrationService
    {
        public Task<UserLoginResponse> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginResponse> SignInAsync(UserLoginViewModel userLoginViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
