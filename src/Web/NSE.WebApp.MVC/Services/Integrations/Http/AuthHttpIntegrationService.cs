using NSE.Shared.Models.Auth;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Providers.Integration;
using NSE.WebApp.MVC.Providers.Utils;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{
    public class AuthHttpIntegrationService(IHttpClientIntegrationProvider httpClientIntegrationProvider,
        IJsonProvider jsonDeserializerProvider) 
        : IAuthHttpIntegrationService
    {
        public async Task<UserLoginResponse> SignInAsync(UserLoginViewModel userLoginViewModel)
        {
            var response = await httpClientIntegrationProvider.PostAsync(userLoginViewModel,
                endpontService: "IdentityEndpoint",
                routeResource: "sign-in");

            return await jsonDeserializerProvider.DeserializeResponse<UserLoginResponse>(response, thowingExceptionBadRequest: true);
        }

        public async Task<UserLoginResponse> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            var response = await httpClientIntegrationProvider.PostAsync(userRegisterViewModel,
                endpontService: "IdentityEndpoint",
                routeResource: "new-account");

            return await jsonDeserializerProvider.DeserializeResponse<UserLoginResponse>(response, thowingExceptionBadRequest: true);

        }
    }
}
