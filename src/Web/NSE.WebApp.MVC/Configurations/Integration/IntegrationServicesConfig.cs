using NSE.API.Provider.Auths.Jwt.Services;
using NSE.API.Provider.Json;
using NSE.WebApp.MVC.Providers.Integration;
using NSE.WebApp.MVC.Services.Integrations.Http;

namespace NSE.WebApp.MVC.Configurations.Integration
{
    public static class IntegrationServicesConfig
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("IntegrationServicesEndpoints");
            services.Configure<IntegrationSettings>(appSettingsSection);

            services.AddHttpClient<IHttpClientIntegrationProvider, HttpClientIntegrationProvider>();
            services.AddSingleton<IJsonResponseService, JsonResponseService>();
            services.AddScoped<IAuthHttpIntegrationService, AuthHttpIntegrationService>();
            services.AddScoped<IAutenticationJwtService, AutenticationJwtService>();
            return services;
        }
    }
}
