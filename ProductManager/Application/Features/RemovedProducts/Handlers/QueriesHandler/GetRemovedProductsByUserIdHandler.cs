using Application.Abstractions;
using Application.Features.RemovedProducts.Requests.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RemovedProducts.Handlers.QueriesHandler
{
    public class GetRemovedProductsByUserIdHandler : IRequestHandler<GetRemovedProductsByUserId, ICollection<RemovedProduct>>
    {
        private readonly IRemovedProductRepository _removedProductRepo;

        public GetRemovedProductsByUserIdHandler(IRemovedProductRepository repo)
        {
            _removedProductRepo = repo;
        }
        public async Task<ICollection<RemovedProduct>> Handle(GetRemovedProductsByUserId request, CancellationToken cancellationToken)
        {
            return await _removedProductRepo.GetRemovedProductsByUserId(request.UserId);
        }
    }
}
