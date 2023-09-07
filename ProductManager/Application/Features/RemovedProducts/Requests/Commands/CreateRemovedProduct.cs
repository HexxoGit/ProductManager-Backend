using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Requests.Commands
{
    public class CreateRemovedProduct : IRequest<RemovedProduct>
    {
        public string ProductName { get; set; }
        public string Username { get; set; }
    }
}
