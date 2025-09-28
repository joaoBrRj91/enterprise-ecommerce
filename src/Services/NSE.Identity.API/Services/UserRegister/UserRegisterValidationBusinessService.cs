using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.API.Provider.Validations;
using NSE.Identity.API.Models;
using NSE.Identity.API.Providers;
using NSE.Identity.API.Services;
using NSE.Identity.API.Validations;
using NSE.Shared.Models.Common;

namespace NSE.Identity.API.Services.NewAccount;

public sealed class UserRegisterValidationBusinessService(
    UserManager<IdentityUser> UserManager,
    IAuthProvider AuthProvider,
    UserRegisterModelValidator ValidationRules,
    IValidationIntegrityModelProvider ValidationIntegrity)
    : BaseValidationBusinessService(ValidationIntegrity, AuthProvider), IUserRegisterValidationBusinessService
{
    public async Task<ResponseResult> UserRegisterHandler(UserRegister userRegister)
    {
        var (isUserRegisterValid, responseFailResult) = await UserRegisterIsValid(userRegister);

        if (!isUserRegisterValid) return responseFailResult;

        var identityUser = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            EmailConfirmed = true
        };


        var identityResult = await UserManager.CreateAsync(identityUser, userRegister.Password);

        var (isUserRegisterSuccess, responseResult) = await CheckAndHandleProcessSuccessAsync(identityResult.Succeeded, identityUser.Email);

        if (isUserRegisterSuccess) return responseResult;

        ValidationIntegrity.AddErrors(errorMessages: [.. identityResult.Errors.Select(e=>e.Description)]);
        return ValidationIntegrity.BuildResponseResult();
    }

    private async Task<(bool, ResponseResult)> UserRegisterIsValid(UserRegister userRegister)
      => DataIsValid(await ValidationRules.ValidateAsync(userRegister));
}
