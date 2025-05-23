using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identity.API.Configurations;
using NSE.Identity.API.Data;
using NSE.Identity.API.Endpoints;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configution = builder.Configuration;

builder.Services
    .AddCommonApiServices(configution)
    .AddAuthenticateServices(configution)
    .AddInfraestructureServices(configution)
    .AddBusinessServices();

var app = builder.Build();

//Extension Methods for use

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("api/identity/v1").WithOpenApi().MapCarter();

app.Run();

