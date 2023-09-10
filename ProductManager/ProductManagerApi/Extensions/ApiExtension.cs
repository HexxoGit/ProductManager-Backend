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
using Application.Features.RecordCalls.Requests.Commands;
using Application.Features.RecordCalls.Requests.Queries;
using Infrastructure.Middleware;
using Application.Abstractions.Persistance;
using Application.Abstractions.Infrastructure;
using Application.Services.RemovedProductService;

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
            builder.Services.AddScoped<ICallRecordRepository, CallRecordRepository>();
            builder.Services.AddScoped<IRemovedProudctService, RemovedProductService>();
            builder.Services.AddScoped<CallRecordMiddleware>();
            builder.Services.AddHttpClient<ExternalProductsApiService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "ProductManagerApi", Version = "v1" });
            });
            //builder.Services.AddAuthentication().AddJwtBearer();

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.SaveToken = false;
                config.RequireHttpsMetadata = false;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                    //ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("Jwt:Token").Value)),
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ProductManager", policy =>
                {
                    policy.RequireRole("ProductManager");
                });
            });
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<AuthenticateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateUser>();
                cfg.RegisterServicesFromAssemblyContaining<CreateRemovedProduct>();
                cfg.RegisterServicesFromAssemblyContaining<GetRemovedProductsByUsername>();
                cfg.RegisterServicesFromAssemblyContaining<CreateCallRecord>();
                cfg.RegisterServicesFromAssemblyContaining<GetCallRecords>();
                cfg.RegisterServicesFromAssemblyContaining<GetCallRecordsByUsername>();
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
