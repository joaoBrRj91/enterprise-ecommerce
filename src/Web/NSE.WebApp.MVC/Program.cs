using NSE.WebApp.MVC.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebMvcConfiguration();

var app = builder.Build();

app.UseWebMvcConfiguration(app.Environment);

app.Run();
