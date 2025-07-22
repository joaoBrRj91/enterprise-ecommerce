using NSE.Identity.API.Models;
using NSE.Shared.Models.Common.Validations;

namespace NSE.Identity.API.Services.SignIn;

public interface ISignInValidationBusinessService
{
    public Task<ResponseResult> SignInHandler(UserData userLogin);
}
