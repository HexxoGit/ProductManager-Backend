using Application.Abstractions.Infrastructure;
using Application.Features.RecordCalls.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Handlers.QueryHandler
{
    internal class GetCallRecordsHandler : IRequestHandler<GetCallRecords, List<CallRecord>>
    {
        private readonly ICallRecordService _callRecordService;

        public GetCallRecordsHandler(ICallRecordService service)
        {
            _callRecordService = service;
        }
        public async Task<List<CallRecord>> Handle(GetCallRecords request, CancellationToken cancellationToken)
        {
            return await _callRecordService.GetAllCallRecords();
        }
    }
}
