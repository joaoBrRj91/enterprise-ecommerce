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
    .AddAuthenticateServices(configution)
    .AddCommonApiServices(configution)
    .AddInfraestructureServices(configution)
    .AddBusinessServices();

var app = builder.Build();

app.UseAuthenticateServices()
    .UseCommonApiServices();

app.Run();

