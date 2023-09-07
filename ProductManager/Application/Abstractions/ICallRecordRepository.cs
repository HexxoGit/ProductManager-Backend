using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ICallRecordRepository
    {
        Task<CallRecord> CreateCallRecord(CallRecord callRecord);
        Task<List<CallRecord>> GetCallRecords();
        Task<List<CallRecord>> GetCallRecordsByUsername(string username);
    }
}
