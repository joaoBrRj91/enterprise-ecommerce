using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Endpoints;

public class IdentityEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-in", async ([FromBody] UserData userLogin, SignInManager<IdentityUser> signInManager) =>
        {
            var identityResult = await signInManager
            .PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);

            if (identityResult.Succeeded)
                return Results.Created();

            return Results.BadRequest();

        })
        .WithName("GetIdentityUser");

        app.MapPost("/new-account", async ([FromBody] UserRegister userRegister, UserManager<IdentityUser> userManager) =>
        {
            var identityUser = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = false
            };

            var identityResult = await userManager.CreateAsync(identityUser, userRegister.Password);

            if (identityResult.Succeeded)
                return Results.Created();

            return Results.BadRequest();

        })
         .WithName("CreateIdentityUser");
    }
}
