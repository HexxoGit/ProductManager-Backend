
using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.Users.Request.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repo)
        {
            _userRepository = repo;
        }

        public async Task<User> CreateUser(CreateUser userRequest)
        {
            var newUser = new User
            {
                Username = userRequest.Username,
                Password = userRequest.Password,
                Role = "ProductManager"
            };
            return await _userRepository.CreateUser(newUser);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<string> LoginUser(AuthenticateUser user)
        {
            var existingUser = await _userRepository.GetUserByUsername(user.Username);

            if (existingUser != null && existingUser.Password == user.Password)
            {
                var token = GenerateJwtToken(existingUser);
                return token;
            }
            return "User does not exist or password incorrect!";
        }

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("6ceccd7405ef4b00b2630009be568cfa91238aewydzt"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://localhost:7037",
                Audience = "https://localhost:7037",
                Expires = DateTime.Now.AddMinutes(200),
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
