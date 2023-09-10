using Application.Abstractions.Persistance;
using Application.Features.RecordCalls.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Handlers.QueryHandler
{
    internal class GetCallRecordsHandler : IRequestHandler<GetCallRecords, List<CallRecord>>
    {
        private readonly ICallRecordRepository _callRecordRepository;

        public GetCallRecordsHandler(ICallRecordRepository repo)
        {
            _callRecordRepository = repo;
        }
        public async Task<List<CallRecord>> Handle(GetCallRecords request, CancellationToken cancellationToken)
        {
            return await _callRecordRepository.GetCallRecords();
        }
    }
}
