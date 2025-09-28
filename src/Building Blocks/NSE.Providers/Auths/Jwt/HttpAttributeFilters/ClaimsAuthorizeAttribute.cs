using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace NSE.API.Provider.Auths.Jwt.HttpAttributeFilters;

public class ClaimsAuthorizeAttribute : TypeFilterAttribute
{
    public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
    {
        Arguments = [new Claim(claimName, claimValue)];
    }
}


class RequisitoClaimFilter(Claim claim) : IAuthorizationFilter
{
    private readonly Claim _claim = claim;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        if (!UserClaimsIsValid(context.HttpContext, _claim.Type, _claim.Value))
        {
            context.Result = new StatusCodeResult(403);
        }
    }

    public static bool UserClaimsIsValid(HttpContext context, string claimName, string claimValue)
    {
        return context.User.Identity!.IsAuthenticated &&
               context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
    }

}
