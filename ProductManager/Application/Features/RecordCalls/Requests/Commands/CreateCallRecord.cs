using Domain.Entities;
using MediatR;

namespace Application.Features.RecordCalls.Requests.Commands
{
    public class CreateCallRecord : IRequest<CallRecord>
    {
        public string? IP { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestPath { get; set; }
        public int UserId { get; set; }
    }
}
