using ProductManagerApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.UseAuthentication();

app.UseHttpsRedirection();
app.RegisterEndpointDefinitions();

app.Run();
