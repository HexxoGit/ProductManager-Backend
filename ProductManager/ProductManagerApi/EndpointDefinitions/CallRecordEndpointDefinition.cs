using Application.Features.RecordCalls.Requests.Queries;
using MediatR;
using ProductManagerApi.Abstractions;

namespace ProductManagerApi.EndpointDefinitions
{
    public class CallRecordEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var callRecords = app.MapGroup("/api/records");

            callRecords.MapGet("", GetRecords);
            callRecords.MapGet("/user", GetRecordsByUser);
        }

        private async Task<IResult> GetRecords(IMediator mediator)
        {
            return TypedResults.Ok(await mediator.Send(new GetCallRecords()));
        }

        private async Task<IResult> GetRecordsByUser(IMediator mediator)
        {
            return null;
        }

    }
}
