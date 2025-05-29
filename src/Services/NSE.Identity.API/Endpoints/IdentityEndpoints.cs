using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;
using NSE.Identity.API.Providers;

namespace NSE.Identity.API.Endpoints;

public class IdentityEndpoints(IAuthProvider authProvider) : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-in", async ([FromBody] UserData userLogin, SignInManager<IdentityUser> signInManager) =>
        {
            var identityResult = await signInManager
            .PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);

            if (identityResult.Succeeded)
                return Results.Ok(await authProvider.GenerateTokenAsync(userLogin.Email));

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
                return Results.Created(string.Empty, await authProvider.GenerateTokenAsync(userRegister.Email));

            return Results.BadRequest();

        })
         .WithName("CreateIdentityUser");
    }
}
