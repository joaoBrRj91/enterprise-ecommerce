using Microsoft.AspNetCore.Identity;
using NSE.Identity.API.Models;
using NSE.Identity.API.Providers;
using NSE.Identity.API.Services;
using NSE.Identity.API.Validations;
using NSE.Shared.Models.Common;
using NSE.Shared.Services.Validations;

namespace NSE.Identity.API.Services.SignIn;

public sealed class SignInValidationBusinessService(
    SignInManager<IdentityUser> SignInManager,
    IAuthProvider AuthProvider,
    UserDataModelValidator ValidationRules,
    IValidationIntegrityModelService ValidationIntegrity)
    : BaseValidationBusinessService(ValidationIntegrity,AuthProvider), ISignInValidationBusinessService
{

    public async Task<ResponseResult> SignInHandler(UserData userLogin)
    {
        var (isUserValid, responseFailResult) = await UserDataIsValid(userLogin);

        if (!isUserValid) return responseFailResult;

        var signInResult = await SignInManager
            .PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);

        var (isSignSuccess, responseResult) = await CheckAndHandleProcessSuccessAsync(signInResult.Succeeded, userLogin.Email);

        if (isSignSuccess) return responseResult;

        ValidationIntegrity.AddError(errorMessage: signInResult.ToString());
        return ValidationIntegrity.BuildResponseResult();
    }

    private async Task<(bool, ResponseResult)> UserDataIsValid(UserData userLogin) 
        => DataIsValid(await ValidationRules.ValidateAsync(userLogin));
}
