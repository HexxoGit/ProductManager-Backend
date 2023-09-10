using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RecordCalls.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Handlers.CommandHandler
{
    public class CreateCallRecordHandler : IRequestHandler<CreateCallRecord, CallRecord>
    {
        private readonly ICallRecordService _callRecordService;

        public CreateCallRecordHandler(ICallRecordService service)
        {
            _callRecordService = service;
        }
        public async Task<CallRecord> Handle(CreateCallRecord request, CancellationToken cancellationToken)
        {
            return await _callRecordService.CreateCallRecord(request);
        }
    }
}
