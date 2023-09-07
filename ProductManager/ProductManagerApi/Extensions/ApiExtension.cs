using Application.Abstractions;
using Infrastructure.DataAcess.Repositories;
using Infrastructure.DataAcess;
using Infrastructure.ExternalServiceIntegration;
using Microsoft.EntityFrameworkCore;
using ProductManagerApi.Abstractions;
using Infrastructure.Services;
using Application.Features.RemovedProducts.Requests.Commands;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Users.Request.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MediatR;
using System.Reflection;

namespace ProductManagerApi.Extensions
{
    public static class ApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ManagerDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRemovedProductRepository, RemovedProductRepository>();
            builder.Services.AddHttpClient<ExternalProductsApiService>();
            builder.Services.AddAuthentication().AddJwtBearer();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AuthenticateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateRemovedProduct>();
            });
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.RegisterEndpoints(app);
            }
        }
    }
}
