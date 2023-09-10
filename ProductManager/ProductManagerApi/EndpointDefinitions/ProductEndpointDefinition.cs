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

            products.MapGet("/categories", GetCategories);
            products.MapGet("", GetProducts);//.RequireAuthorization("ProductManager");
            products.MapGet("/remove", GetRemovedProducts);
            products.MapPost("/remove", RemoveProduct);
        }

        private async Task<IResult> GetCategories(ExternalProductsApiService externalProductsApiService)
        {
            return TypedResults.Ok(await externalProductsApiService.GetAllProductsCategories());
        }

        private async Task<IResult> GetProducts(ExternalProductsApiService externalProductsApiService,
                    decimal? minPrice, decimal? maxPrice, int? minStock, int? maxStock, string? category)
        {
            return TypedResults.Ok(await externalProductsApiService.GetAllProducts(
                     "FirstUser", minPrice, maxPrice, minStock, maxStock, category));
        }

        private async Task<IResult> RemoveProduct(IMediator mediator, string productName)
        {
            CreateRemovedProduct cmd = 
                new CreateRemovedProduct() { ProductName = productName, Username = "FirstUser" };
            return TypedResults.Ok(await mediator.Send(cmd));
        }

        private async Task<IResult> GetRemovedProducts(IMediator mediator)
        {
            GetRemovedProductsByUsername cmd = 
                new GetRemovedProductsByUsername { Username = "FirstUser" };      
            return TypedResults.Ok(await mediator.Send(cmd));
        }
    }
}
