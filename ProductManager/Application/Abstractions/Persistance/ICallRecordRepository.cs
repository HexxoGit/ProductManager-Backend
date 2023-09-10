using Domain.Entities;

namespace Application.Abstractions.Persistance
{
    public interface ICallRecordRepository
    {
        Task<CallRecord> CreateCallRecord(CallRecord callRecord);
        Task<List<CallRecord>> GetCallRecords();
        Task<List<CallRecord>> GetCallRecordsByUsername(string username);
    }
}
