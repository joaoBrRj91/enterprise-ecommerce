using Microsoft.AspNetCore.Authentication.Cookies;

namespace NSE.WebApp.MVC.Configurations.Auth
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = Constants.LoginPath;
                    options.AccessDeniedPath = Constants.AccessDeniedPath;
                });

            services.AddAuthorizationBuilder()
                .AddPolicy(Constants.AdminPolicy, policy => policy.RequireRole(Constants.AdminPolicy))
                .AddPolicy(Constants.UserPolicy, policy => policy.RequireRole(Constants.UserPolicy));

            return services;
        }

        public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
