using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NSE.Catalog.API.Data;
using NSE.Catalog.API.Endpoints;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Configurations.SetupApp;

public static class AddAppConfig
{
    public static IServiceCollection AddCommonApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "NerdStore Enterprise Catalog API",
                Description = "This API is catalog application for all other distributed systems.",
                Contact = new OpenApiContact() { Name = "João Nascimento", Email = "test@test.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });

        });

        services.AddCarter(new DependencyContextAssemblyCatalog(typeof(Program).Assembly), config =>
        {
            config.WithModule<CatalogEndpoints>();
        });

        return services;

    }

    public static IServiceCollection AddAuthenticateServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(
         opt => opt.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;

    }
}
