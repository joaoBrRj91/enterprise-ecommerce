using NSE.Identity.API.Models;
using NSE.Shared.Models.Common.Validations;

namespace NSE.Identity.API.Services.NewAccount;

public interface IUserRegisterValidationBusinessService
{
    public Task<ResponseResult> UserRegisterHandler(UserRegister userRegister);
}
