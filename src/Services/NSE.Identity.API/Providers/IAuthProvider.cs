using NSE.Shared.Models.Auth;

namespace NSE.Identity.API.Providers
{
    public interface IAuthProvider
    {
        public Task<UserLoginResponse> GenerateTokenAsync(string email);
    }
}
