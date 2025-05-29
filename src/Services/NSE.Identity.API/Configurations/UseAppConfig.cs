using Carter;

namespace NSE.Identity.API.Configurations
{
    public static class UseAppConfig
    {
        public static WebApplication UseAuthenticateServices(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }

        public static WebApplication UseCommonApiServices(this WebApplication app)
        {
            app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }


            app.MapGroup("api/identity/v1").WithOpenApi().MapCarter();
            return app;
        }
    }
}
