using Application.Abstractions.Infrastructure;
using Application.Features.RecordCalls.Requests.Commands;

namespace ProductManagerApi.Middleware
{
    public class CallRecordMiddleware : IMiddleware
    {
        private readonly ICallRecordService _callRecordService;

        public CallRecordMiddleware(ICallRecordService service)
        {
            _callRecordService = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers.ContainsKey("IpAddress"))
            {
                var ip = context.Connection.RemoteIpAddress.ToString();
                var requestMethod = context.Request.Method;
                var requestPath = context.Request.Path;
                var userId = 1;

                var callRecord = new CreateCallRecord
                {
                    IP = ip,
                    RequestMethod = requestMethod,
                    RequestPath = requestPath,
                    UserId = userId
                };

                await _callRecordService.CreateCallRecord(callRecord);
                await next.Invoke(context);
            }
            else
                await next.Invoke(context);
        }
    }
}
