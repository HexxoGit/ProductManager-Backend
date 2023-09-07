using Domain.Entities;

namespace Application.Abstractions
{
    public interface IRemovedProductRepository
    {
        Task<RemovedProduct> CreateRemovedProduct(RemovedProduct product);
        Task<List<RemovedProduct>> GetRemovedProducts();
        Task<List<RemovedProduct>> GetRemovedProductsByUsername(string username);
    }
}
