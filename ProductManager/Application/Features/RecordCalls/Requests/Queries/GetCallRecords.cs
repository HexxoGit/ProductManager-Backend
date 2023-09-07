using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Requests.Queries
{
    public class GetCallRecords : IRequest<List<CallRecord>>
    {
    }
}
