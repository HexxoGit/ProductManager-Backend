using Application.Abstractions;
using Infrastructure.DataAcess.Repositories;
using Infrastructure.DataAcess;
using Infrastructure.ExternalServiceIntegration;
using Microsoft.EntityFrameworkCore;
using ProductManagerApi.Abstractions;
using Application.Features.RemovedProducts.Requests.Commands;
using Application.Features.Users.Request.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MediatR;
using System.Text;
using Application.Features.RemovedProducts.Requests.Queries;

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
            //builder.Services.AddAuthentication().AddJwtBearer();

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.SaveToken = true;
                config.RequireHttpsMetadata = false;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6ceccd7405ef4b00b2630009be568cfa91238aewydzt")),
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ProductManager", policy =>
                {
                    policy.RequireClaim("ProductManager");
                });
            });
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AuthenticateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateRemovedProduct>();
                cfg.RegisterServicesFromAssemblyContaining<GetRemovedProductsByUsername>();
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
