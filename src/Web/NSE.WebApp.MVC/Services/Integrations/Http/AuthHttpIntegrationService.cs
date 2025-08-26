using NSE.Shared.Models.Auths;
using NSE.Shared.Models.Common;
using NSE.Shared.Providers;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Providers.Integration;

namespace NSE.WebApp.MVC.Services.Integrations.Http
{

    // TODO: Refatorar para ser de forma abastrata, pois sera usado por diversos contextos
    public class AuthHttpIntegrationService(IHttpClientIntegrationProvider httpClientIntegrationProvider,
        IJsonResponseProvider jsonResponseProvider) 
        : IAuthHttpIntegrationService
    {
        public async Task<ResponseResult> SignInAsync(UserLoginViewModel userLoginViewModel)
        {
            var response = await httpClientIntegrationProvider.PostAsync(userLoginViewModel,
                endpontService: "IdentityEndpoint",
                routeResource: "sign-in");

            return await jsonResponseProvider.DeserializeResponse<ResponseResult>(response, thowingExceptionBadRequest: true);
        }

        public async Task<ResponseResult> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
        {
            var response = await httpClientIntegrationProvider.PostAsync(userRegisterViewModel,
                endpontService: "IdentityEndpoint",
                routeResource: "new-account");

            return await jsonResponseProvider.DeserializeResponse<ResponseResult>(response, thowingExceptionBadRequest: true);

        }

    }
}
