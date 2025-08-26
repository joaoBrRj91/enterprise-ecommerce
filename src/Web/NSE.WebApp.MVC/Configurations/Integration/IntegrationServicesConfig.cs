using NSE.Shared.Providers;
using NSE.Shared.Services.Auths.Jwt;
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
            services.AddSingleton<IJsonResponseProvider, JsonResponseProvider>();
            services.AddScoped<IAuthHttpIntegrationService, AuthHttpIntegrationService>();
            services.AddScoped<IAutenticationJwtService, AutenticationJwtService>();
            return services;
        }
    }
}
