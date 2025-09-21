using NSE.Catalog.API.Configurations;
using NSE.Catalog.API.Configurations.SetupApp;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.ConfigureAppSettingsEnvironment(builder.Environment.ContentRootPath);

var configution = builder.Configuration;

builder.Services
    .AddCommonApiServices(configution)
    .AddInfraestructureServices(configution)
    .AddAuthenticateServices(configution);


var app = builder.Build();

app.UseCommonApiServices();

app.Run();
