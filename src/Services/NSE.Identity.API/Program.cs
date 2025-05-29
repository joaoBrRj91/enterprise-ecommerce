using NSE.Identity.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

var configution = builder.Configuration;

builder.Services
    .AddAuthenticateServices(configution)
    .AddCommonApiServices(configution)
    .AddInfraestructureServices(configution)
    .AddBusinessServices();

var app = builder.Build();

app.UseAuthenticateServices()
    .UseCommonApiServices();

app.Run();

