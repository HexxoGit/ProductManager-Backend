using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Requests.Queries
{
    public class GetCallRecordsByUsername : IRequest<List<CallRecord>>
    {
        public string? Username { get; set; }
    }
}
