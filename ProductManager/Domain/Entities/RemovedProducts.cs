
namespace Domain.Entities
{
    public class RemovedProduct
    {
        public int RemovedProductId { get; set; }
        public int UserId { get; set; }
        public string? ProductName { get; set; }
    }
}
