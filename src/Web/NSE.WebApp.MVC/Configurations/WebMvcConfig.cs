using NSE.WebApp.MVC.Configurations.Auth;

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
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthConfiguration(env);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
