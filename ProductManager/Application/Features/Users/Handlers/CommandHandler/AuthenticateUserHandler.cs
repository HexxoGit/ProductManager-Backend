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
                var token = GenerateJwtToken(request.Username);
                return token;
            }
            return "User not found or password incorrect!";
        }

        public string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6ceccd7405ef4b00b2630009be568cfa91238aewydzt"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
