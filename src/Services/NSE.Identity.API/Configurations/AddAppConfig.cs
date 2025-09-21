using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identity.API.Data;
using NSE.Identity.API.Endpoints;
using NSE.Identity.API.Providers;
using NSE.Providers.Auths.Jwt.Extensions;
using NSE.Providers.Validations;
using System.Text;

namespace NSE.Identity.API.Configurations
{
    public static class AddAppConfig
    {
        public static IServiceCollection AddCommonApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Identity API",
                    Description = "This API is identity application for all other distributed systems.",
                    Contact = new OpenApiContact() { Name = "João Nascimento", Email = "test@test.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

            });

            services.AddCarter(new DependencyContextAssemblyCatalog(typeof(Program).Assembly), config =>
            {
                config.WithModule<IdentityEndpoints>();
            });

            return services;

        }

        public static IServiceCollection AddAuthenticateServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddJwtAuthentication(configuration);
            services.AddSingleton<IAuthProvider, AuthProvider>();

            return services;
        }

        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
             opt => opt.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;

        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            services.AddScoped<IValidationIntegrityModelProvider, ValidationIntegrityModelProvider>();
            return services;
        }
    }
}