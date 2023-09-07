using Domain.Entities;

namespace Application.Abstractions
{
    public interface IRemovedProductRepository
    {
        Task<RemovedProduct> CreateRemovedProduct(RemovedProduct product);
        Task<ICollection<RemovedProduct>> GetRemovedProducts();
        Task<ICollection<RemovedProduct>> GetRemovedProductsByUserId(int userId);
    }
}
