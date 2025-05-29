using NSE.Identity.API.Models;

namespace NSE.Identity.API.Providers
{
    public interface IAuthProvider
    {
        public Task<UserLoginResponse> GenerateTokenAsync(string email);
    }
}
