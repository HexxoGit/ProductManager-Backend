using Application.Features.RecordCalls.Requests.Commands;
using Domain.Entities;

namespace Application.Abstractions.Infrastructure
{
    public interface ICallRecordService
    {
        Task<CallRecord> CreateCallRecord(CreateCallRecord request);
        Task<List<CallRecord>> GetAllCallRecords();
        Task<List<CallRecord>> GetCallRecordsByUsername(string username);
    }
}
