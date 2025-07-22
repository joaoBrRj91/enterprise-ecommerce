using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSE.Identity.API.Configurations;
using NSE.Shared.Models.Auths;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NSE.Identity.API.Providers
{
    public class AuthProvider(UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings) : IAuthProvider
    {
        public async Task<UserLoginResponse> GenerateTokenAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var claimsIdentity = await GetClaimsIdentityUserAsync(user);

            var token = WriteToken(claimsIdentity);
            return CreateUserResponse(token, claimsIdentity);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentityUserAsync(IdentityUser user)
        {
            static long ToUnixEpochDate(DateTime date)
            {
                return (long)Math
                     .Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                     .TotalSeconds);
            }

            var claims = userManager.GetClaimsAsync(user);
            var userRoles = userManager.GetRolesAsync(user);

            await Task.WhenAll(claims, userRoles);

            claims.Result.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Result.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Result.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Result.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Result.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles.Result)
            {
                claims.Result.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims.Result);

            return identityClaims;
        }

        private string WriteToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = appSettings.Value.Issue,
                Audience = appSettings.Value.AudienceIn,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(appSettings.Value.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);

        }

        private UserLoginResponse CreateUserResponse(string token, ClaimsIdentity claimsIdentity)
        {
            return new UserLoginResponse
            {
                AccessToken = token,
                ExpiresIn = TimeSpan.FromHours(appSettings.Value.ExpiresInHours).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = claimsIdentity.Claims.FirstOrDefault(c=>c.Type == JwtRegisteredClaimNames.Sub).Value,
                    Email = claimsIdentity.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value,
                    Claims = claimsIdentity.Claims.Select(c=> new UserClaim { Type = c.Type, Value = c.Value})
                }
            };
        }
    }
}
