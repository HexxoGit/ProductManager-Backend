using Application.Abstractions;
using Application.Features.Users.Request.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Features.Users.Handlers.CommandHandler
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUser, string>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUserHandler(IUserRepository repo)
        {
            _userRepository = repo;
        }
        
        public async Task<string> Handle(AuthenticateUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);

            if(user != null && user.Password == request.Password)
            {
                var token = GenerateJwtToken(user);
                return token;
            }
            return "User not found or password incorrect!";
        }

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6ceccd7405ef4b00b2630009be568cfa91238aewydzt"));

            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://localhost:7037",
                Audience = "https://localhost:7037",
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                })
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
