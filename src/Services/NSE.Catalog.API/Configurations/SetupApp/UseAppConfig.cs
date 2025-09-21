using Carter;

namespace NSE.Catalog.API.Configurations.SetupApp;

public static class UseAppConfig
{
    public static WebApplication UseCommonApiServices(this WebApplication app)
    {
        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
        }


        app.MapGroup("api/catalog/v1").WithOpenApi().MapCarter();
        return app;
    }

    public static WebApplication UseAuthenticateServices(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
