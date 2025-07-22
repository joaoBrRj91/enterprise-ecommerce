
using NSE.Shared.Models.Auths;

namespace NSE.Identity.API.Providers
{
    public interface IAuthProvider
    {
        public Task<UserLoginResponse> GenerateTokenAsync(string email);
    }
}
