using Carter;

namespace NSE.Identity.API.Endpoints;

public class IdentityEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/user", async () =>
        {
            var content = await new StringContent("User Identity").ReadAsStringAsync();
            return Results.Ok(content);
        })
         .WithName("GetIdentityUser")
         .WithOpenApi();
    }
}
