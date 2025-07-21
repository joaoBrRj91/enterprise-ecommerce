using NSE.WebApp.MVC.Configurations;
using NSE.WebApp.MVC.Configurations.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebMvcConfiguration()
    .AddIntegrationServices(builder.Configuration);

var app = builder.Build();

app.UseWebMvcConfiguration(app.Environment);

app.Run();
