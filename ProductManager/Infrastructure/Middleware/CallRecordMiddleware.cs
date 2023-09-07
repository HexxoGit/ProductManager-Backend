using Domain.Entities;
using Infrastructure.DataAcess;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware
{
    public class CallRecordMiddleware : IMiddleware
    {
        private readonly ManagerDbContext _dbContext;

        public CallRecordMiddleware(ManagerDbContext context)
        {
            _dbContext = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var dateTime = DateTime.Now;
            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var userId = 1;

            var callRecord = new CallRecord
            {
                IP = ip,
                DateTime = dateTime,
                RequestMethod = requestMethod,
                RequestPath = requestPath,
                UserId = userId
            };

            _dbContext.CallRecords.Add(callRecord);
            await _dbContext.SaveChangesAsync();

            await next.Invoke(context);
        }
    }
}
