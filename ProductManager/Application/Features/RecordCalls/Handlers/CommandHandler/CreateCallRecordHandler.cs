using Application.Abstractions;
using Application.Features.RecordCalls.Requests.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RecordCalls.Handlers.CommandHandler
{
    public class CreateCallRecordHandler : IRequestHandler<CreateCallRecord, CallRecord>
    {
        private readonly ICallRecordRepository _callRecordRepository;

        public CreateCallRecordHandler(ICallRecordRepository repo)
        {
            _callRecordRepository = repo;
        }
        public async Task<CallRecord> Handle(CreateCallRecord request, CancellationToken cancellationToken)
        {
            var callRecord = new CallRecord
            {
                IP = request.IP,
                DateTime = DateTime.Now,
                RequestMethod = request.RequestMethod,
                RequestPath = request.RequestPath,
                UserId = request.UserId
            };

            return await _callRecordRepository.CreateCallRecord(callRecord);
        }
    }
}
