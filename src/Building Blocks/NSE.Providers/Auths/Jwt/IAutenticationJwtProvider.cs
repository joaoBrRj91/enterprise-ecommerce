using Microsoft.AspNetCore.Authentication;
using NSE.Shared.Models.Auths;
using System.Security.Claims;

namespace NSE.API.Provider.Auths.Jwt;

public interface IAutenticationJwtProvider
{
    public (ClaimsPrincipal, AuthenticationProperties) BuildTokenPrincipalInformations(
        UserLoginResponse userLoginResponse,
        double expiresMinutesUtc = 10,
        bool isPersistence = false,
        AuthType authenticationType = AuthType.Jwt);
}
