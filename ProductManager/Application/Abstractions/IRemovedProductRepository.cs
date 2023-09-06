using Domain.Entities;

namespace Application.Abstractions
{
    public interface IRemovedProductRepository
    {
        Task<RemovedProduct> CreateRemovedProduct(RemovedProduct product);
        Task<ICollection<RemovedProduct>> GetAllRemovedProducts();
        Task<ICollection<RemovedProduct>> GetAllRemovedProductsByUserId(int userId);
    }
}
