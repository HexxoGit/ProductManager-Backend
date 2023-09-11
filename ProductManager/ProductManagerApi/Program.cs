using ProductManagerApi.Extensions;
using ProductManagerApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseMiddleware<CallRecordMiddleware>();

app.UseHttpsRedirection();
app.RegisterEndpointDefinitions();

app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1")
);

app.Run();
