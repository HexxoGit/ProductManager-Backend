using Infrastructure.Middleware;
using ProductManagerApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CallRecordMiddleware>();

app.UseHttpsRedirection();
app.RegisterEndpointDefinitions();

app.Run();
