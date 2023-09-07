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
    public class GetRemovedProductsByUsernameHandler : IRequestHandler<GetRemovedProductsByUsername, List<RemovedProduct>>
    {
        private readonly IRemovedProductRepository _removedProductRepo;

        public GetRemovedProductsByUsernameHandler(IRemovedProductRepository repo)
        {
            _removedProductRepo = repo;
        }
        public async Task<List<RemovedProduct>> Handle(GetRemovedProductsByUsername request, CancellationToken cancellationToken)
        {
            return await _removedProductRepo.GetRemovedProductsByUsername(request.Username);
        }
    }
}
