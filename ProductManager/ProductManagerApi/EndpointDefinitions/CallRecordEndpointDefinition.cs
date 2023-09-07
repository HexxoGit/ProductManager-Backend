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

            callRecords.MapGet("", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCallRecords());
                return Results.Ok(result);
            });

            callRecords.MapGet("/user", async(IMediator mediator) =>
            {

            });
        }
    }
}
