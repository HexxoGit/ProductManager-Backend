using System.Text.Json.Serialization;

namespace Application.DTOs.Product.Responses
{
    public class ProductResponse
    {
        [JsonPropertyName("products")]
        public List<ProductItemResponse>? Products { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("skip")]
        public int Skip { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
    }
}
