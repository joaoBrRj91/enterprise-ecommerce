using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using NSE.Shared.Models.Auths;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.Providers.Auths.Jwt;

public sealed class AutenticationJwtProvider : IAutenticationJwtProvider
{
    private const string JWT_CLAIM_TYPE = "JWT";

    public (ClaimsPrincipal, AuthenticationProperties) BuildTokenPrincipalInformations(
        UserLoginResponse userLoginResponse,
        double expiresMinutesUtc = 10,
        bool isPersistence = false,
        AuthType authenticationType = AuthType.Jwt)
    {
        var formatTokenInformations = GetFormatToken(userLoginResponse.AccessToken);

        var claims = new List<Claim>
        {
            new(JWT_CLAIM_TYPE, userLoginResponse.AccessToken)
        };

        claims.AddRange(formatTokenInformations.Claims);

        var claimsIdentity = new ClaimsIdentity(claims, authenticationType.ToString());

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(expiresMinutesUtc),
            IsPersistent = authenticationType != AuthType.Jwt && isPersistence
        };

        return (new ClaimsPrincipal(claimsIdentity), authProperties);
    }

    private static JwtSecurityToken GetFormatToken(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token);
}
