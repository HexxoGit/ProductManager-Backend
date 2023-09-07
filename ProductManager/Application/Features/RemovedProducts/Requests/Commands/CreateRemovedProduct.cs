using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Requests.Commands
{
    public class CreateRemovedProduct : IRequest<RemovedProduct>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
