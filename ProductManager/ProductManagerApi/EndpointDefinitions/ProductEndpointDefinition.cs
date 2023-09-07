using Application.DTOs.Product;
using Application.Features.RemovedProducts.Requests.Commands;
using Application.Features.RemovedProducts.Requests.Queries;
using Infrastructure.ExternalServiceIntegration;
using MediatR;
using ProductManagerApi.Abstractions;
using System.Security.Claims;
using System.Text.Json;

namespace ProductManagerApi.EndpointDefinitions
{
    public class ProductEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var products = app.MapGroup("/api/products");

            products.MapGet("/categories", async (HttpContext context, ExternalProductsApiService externalProductsApiService) =>
            {
                List<string> categories = await externalProductsApiService.GetAllProductsCategories();
                await JsonSerializer.SerializeAsync(context.Response.Body, categories);
            });

            /*
             * TODO: Refactor ter em conta o nome do utilizador diretamente do token
             */
            products.MapGet("", async (HttpContext context, /*ClaimsPrincipal user,*/ ExternalProductsApiService externalProductsApiService,
                    decimal? minPrice, decimal? maxPrice, int? minStock, int? maxStock, string? category) =>
            {
                List<ProductDTO> products = await externalProductsApiService.GetAllProducts(
                     "FirstUser", minPrice, maxPrice, minStock, maxStock, category);
                await JsonSerializer.SerializeAsync(context.Response.Body, products);
            });//.RequireAuthorization("ProductManager");

            products.MapPost("/remove", async (IMediator mediator, string productName) =>
            {
                CreateRemovedProduct cmd = new CreateRemovedProduct();
                cmd.ProductName = productName;
                cmd.Username = "FirstUser";

                var removedProduct = await mediator.Send(cmd);
                return Results.Ok(removedProduct);
            });

            products.MapGet("/remove", async (IMediator mediator) =>
            {
                GetRemovedProductsByUsername cmd = new GetRemovedProductsByUsername();
                cmd.Username = "FirstUser";

                var result = await mediator.Send(cmd);
                return Results.Ok(result);
            });
        }
    }
}
