using Microsoft.AspNetCore.Authentication;
using NSE.Shared.Models.Auths;
using System.Security.Claims;

namespace NSE.Shared.Services.Auths.Jwt;

public interface IAutenticationJwtService
{
    public (ClaimsPrincipal, AuthenticationProperties) BuildTokenPrincipalInformations(
        UserLoginResponse userLoginResponse,
        double expiresMinutesUtc = 10,
        bool isPersistence = false,
        AuthType authenticationType = AuthType.Jwt);
}
