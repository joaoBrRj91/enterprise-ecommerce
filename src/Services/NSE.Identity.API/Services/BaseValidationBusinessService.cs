using FluentValidation.Results;
using NSE.Identity.API.Providers;
using NSE.Shared.Models.Common.Validations;

namespace NSE.Identity.API.Services;

public abstract class BaseValidationBusinessService(IValidationIntegrityModel ValidationIntegrity, IAuthProvider AuthProvider)
{
    protected (bool, ResponseResult) DataIsValid(ValidationResult validationResult)
    {
        if (validationResult.IsValid) return (true, default);

        ValidationIntegrity.AddErrors(errorMessages: [.. validationResult.Errors.Select(e => e.ErrorMessage)]);

        return (false, ValidationIntegrity.BuildResponseResult());
    }

    protected async Task<(bool, ResponseResult)> CheckAndHandleProcessSuccessAsync(bool isResponseSucceeded, string userEmail)
    {
        if (isResponseSucceeded)
        {
            var userRegisterResponse = await AuthProvider.GenerateTokenAsync(userEmail);
            return (true, ValidationIntegrity.BuildResponseResult(userRegisterResponse));
        }

        return (false, default);
    }
}
