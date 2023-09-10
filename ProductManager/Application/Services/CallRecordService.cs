
using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RecordCalls.Requests.Commands;
using Domain.Entities;

namespace Application.Services.CallRecordService
{
    public class CallRecordService : ICallRecordService
    {
        private readonly ICallRecordRepository _callRecordRepository;

        public CallRecordService(ICallRecordRepository repo)
        {
            _callRecordRepository = repo;
        }

        public async Task<CallRecord> CreateCallRecord(CreateCallRecord request)
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

        public async Task<List<CallRecord>> GetAllCallRecords()
        {
            return await _callRecordRepository.GetCallRecords();
        }

        public async Task<List<CallRecord>> GetCallRecordsByUsername(string username)
        {
            return await _callRecordRepository.GetCallRecordsByUsername(username);
        }
    }
}
