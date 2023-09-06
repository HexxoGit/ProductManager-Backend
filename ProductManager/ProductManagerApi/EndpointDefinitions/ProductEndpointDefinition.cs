using Application.DTOs.Product;
using Infrastructure.ExternalServiceIntegration;
using ProductManagerApi.Abstractions;
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

            products.MapGet("", async (HttpContext context, ExternalProductsApiService externalProductsApiService,
                    decimal? minPrice, decimal? maxPrice, int? minStock, int? maxStock, string? category) =>
            {
                List<ProductDTO> products = await externalProductsApiService.GetAllProducts(
                    minPrice, maxPrice, minStock, maxStock, category);
                await JsonSerializer.SerializeAsync(context.Response.Body, products);
            });
        }
    }
}
