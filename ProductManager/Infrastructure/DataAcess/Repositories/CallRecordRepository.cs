using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAcess.Repositories
{
    public class CallRecordRepository : ICallRecordRepository
    {
        private readonly ManagerDbContext _managerDbContext;

        public CallRecordRepository(ManagerDbContext context)
        {
            _managerDbContext = context;
        }
        public async Task<CallRecord> CreateCallRecord(CallRecord callRecord)
        {
            _managerDbContext.Add(callRecord);
            await _managerDbContext.SaveChangesAsync();
            return callRecord;
        }

        public async Task<List<CallRecord>> GetCallRecords()
        {
            return await _managerDbContext.CallRecords.ToListAsync();
        }

        public async Task<List<CallRecord>> GetCallRecordsByUsername(string username)
        {
            return await _managerDbContext.CallRecords
                .Where(callRecord => callRecord.User.Username == username)
                .ToListAsync();
        }
    }
}
