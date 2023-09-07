using Application.Abstractions;
using Application.DTOs.Product;
using Application.DTOs.Product.Responses;
using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.ExternalServiceIntegration
{
    public class ExternalProductsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IRemovedProductRepository _rmvProductRepository;

        public ExternalProductsApiService(HttpClient httpClient, IRemovedProductRepository repo)
        {
            _httpClient = httpClient;
            _rmvProductRepository = repo;
            //_httpClient.BaseAddress = new Uri("https://dummyjson.com/products");
        }

        public async Task<List<string>> GetAllProductsCategories()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://dummyjson.com/products/categories");
                HttpResponseMessage response = await _httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<string> categories = ParseCategories(content);
                    return categories
                        .Where(category => !category.Contains('-'))
                        .ToList(); ;
                }
                else
                    throw new HttpRequestException($"External API returned status code {response.StatusCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAllProducts(string username,
                decimal? minPrice = null, decimal? maxPrice = null,
                int? minStock = null, int? maxStock = null, string? category = null)
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://dummyjson.com/products");
                HttpResponseMessage response = await _httpClient.GetAsync("products");

                List<RemovedProduct> removedProducts = _rmvProductRepository
                    .GetRemovedProductsByUsername(/*username*/"FirstUser").Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var productResponse = JsonSerializer.Deserialize<ProductResponse>(content);

                    List<ProductDTO> products = productResponse.Products
                        .Where(p =>
                            (minPrice == null || p.Price >= minPrice) &&
                            (maxPrice == null || p.Price <= maxPrice) &&
                            (minStock == null || p.Stock >= minStock) &&
                            (maxStock == null || p.Stock <= maxStock) &&
                            (category == null || string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase)) &&
                            (removedProducts == null || !removedProducts
                            .Any(rp => string.Equals(p.Title, rp.ProductName, StringComparison.OrdinalIgnoreCase)))
                        )
                        .Select(p => new ProductDTO
                        {
                            ID = p.ID,
                            Name = p.Title,
                            Description = p.Description,
                            Price = p.Price,
                            Category = p.Category,
                            Stock = p.Stock,
                            Thumbnail = p.Images.FirstOrDefault()
                        })
                    .ToList();
                    return products;
                }
                else
                    throw new HttpRequestException($"External API returned status code {response.StatusCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<string> ParseCategories(string content)
        {
            List<string> categories = new List<string>();
            try
            {
                categories = JsonSerializer.Deserialize<List<string>>(content);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
            return categories;
        }
    }
}
