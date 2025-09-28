using Carter;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Endpoints;

public class CatalogEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/products",
           async ([FromServices] IProductRepository productRepository) =>
       {
           return Results.Ok(await productRepository.GetAll());
       })
        .WithName("GetProducts")
        .Produces<IEnumerable<Product>>(StatusCodes.Status200OK);


        app.MapGet("/products/{id:guid}",
            async ([FromServices] IProductRepository productRepository,
            [FromRoute] Guid id) =>
        {
            return Results.Ok(await productRepository.GetById(id));
        })
        .WithName("GetProduct")
        .Produces<Product>(StatusCodes.Status200OK)
        .RequireAuthorization("CatalogRead");
    }
}
