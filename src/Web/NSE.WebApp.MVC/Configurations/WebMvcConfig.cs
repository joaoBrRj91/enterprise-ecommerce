using NSE.WebApp.MVC.Configurations.Auth;
using NSE.WebApp.MVC.Middlewares;

namespace NSE.WebApp.MVC.Configurations
{
    public static class WebMvcConfig
    {
        public static IServiceCollection AddWebMvcConfiguration(this IServiceCollection services)
        {
            services.AddAuthConfiguration()
                .AddControllersWithViews();
          
            return services;
        }

        public static IApplicationBuilder UseWebMvcConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthConfiguration(env);

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
