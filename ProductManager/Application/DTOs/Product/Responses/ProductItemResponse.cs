using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Product.Responses
{
    public class ProductItemResponse
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("discountPercentage")]
        public double DiscountPercentage { get; set; }
        [JsonPropertyName("rating")]
        public double Rating { get; set; }
        [JsonPropertyName("stock")]
        public int Stock { get; set; }
        [JsonPropertyName("brand")]
        public string Brand { get; set; } = string.Empty;
        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;
        [JsonPropertyName("images")]
        public List<string>? Images { get; set; }
    }
}
