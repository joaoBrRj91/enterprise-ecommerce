using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;
using NSE.Identity.API.Services.NewAccount;
using NSE.Identity.API.Services.SignIn;
using NSE.Shared.Models.Common;

namespace NSE.Identity.API.Endpoints;

public class IdentityEndpoints(
    ISignInValidationBusinessService SignInValidationBusinessService,
    IUserRegisterValidationBusinessService UserRegisterValidationBusinessService) : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-in", async ([FromBody] UserData userLogin) =>
        {
            return CreateHttpResultByResponseResult(await SignInValidationBusinessService.SignInHandler(userLogin));
        })
        .WithName("GetIdentityUser");

        app.MapPost("/new-account", async ([FromBody] UserRegister userRegister) =>
        {
            return CreateHttpResultByResponseResult(await UserRegisterValidationBusinessService.UserRegisterHandler(userRegister));
        })
         .WithName("CreateIdentityUser");
    }

    private IResult CreateHttpResultByResponseResult(ResponseResult responseResult) 
        => responseResult.IsSuccess ? Results.Ok(responseResult) : Results.BadRequest(responseResult);
}
