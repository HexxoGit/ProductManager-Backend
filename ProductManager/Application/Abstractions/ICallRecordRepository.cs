using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICallRecordRepository
    {
        Task<CallRecord> CreateCallRecord(CallRecord callRecord);
        Task<List<CallRecord>> GetCallRecords();
        Task<List<CallRecord>> GetCallRecordsByUsername(string username);
    }
}
