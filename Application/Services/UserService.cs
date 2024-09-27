using Core.Dtos;
using Core.Interfaces;
using Infraestructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Service for managing user authentication.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="configuration">The configuration.</param>
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Logs in a user asynchronously.
        /// </summary>
        /// <param name="loginDto">The login DTO containing the username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the login token if successful.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown when the user or password is invalid.</exception>
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUserNameAndPasswordAsync(loginDto.UserName, Security.GetSHA256(loginDto.Password));
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid user or password");
            }

            return GenerateJwtToken(loginDto);
        }

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="loginDto">The login DTO containing the username.</param>
        /// <returns>The generated JWT token.</returns>
        private string GenerateJwtToken(LoginDto loginDto)
        {
            var jwtSection = _configuration.GetSection("Jwt");
            var key = jwtSection["Key"];
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginDto.UserName),
                new Claim(ClaimTypes.Name, loginDto.UserName)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}