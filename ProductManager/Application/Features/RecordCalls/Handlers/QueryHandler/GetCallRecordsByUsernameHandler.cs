using Application.Abstractions.Infrastructure;
using Application.Features.RecordCalls.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Handlers.QueryHandler
{
    public class GetCallRecordsByUsernameHandler : IRequestHandler<GetCallRecordsByUsername, List<CallRecord>>
    {
        private readonly ICallRecordService _callRecordService;

        public GetCallRecordsByUsernameHandler(ICallRecordService service)
        {
            _callRecordService = service;
        }
        public async Task<List<CallRecord>> Handle(GetCallRecordsByUsername request, CancellationToken cancellationToken)
        {
            return await _callRecordService.GetCallRecordsByUsername(request.Username);
        }
    }
}
