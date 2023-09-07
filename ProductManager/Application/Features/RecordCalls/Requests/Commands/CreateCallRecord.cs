using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
