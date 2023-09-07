using Application.Abstractions;
using Application.Features.RecordCalls.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Handlers.QueryHandler
{
    public class GetCallRecordsByUsernameHandler : IRequestHandler<GetCallRecordsByUsername, List<CallRecord>>
    {
        private readonly ICallRecordRepository _callRecordRepository;

        public GetCallRecordsByUsernameHandler(ICallRecordRepository repo)
        {
            _callRecordRepository = repo;
        }
        public async Task<List<CallRecord>> Handle(GetCallRecordsByUsername request, CancellationToken cancellationToken)
        {
            return await _callRecordRepository.GetCallRecordsByUsername(request.Username);
        }
    }
}
