using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetShop.Business.Models;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Requests.AuthRequest;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Implements
{
    public class AuthService : IAuthService
    {
        public readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Login(LoginRequest request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Username), // Thêm claim về tên người dùng
                new Claim(ClaimType.Role, request.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],   // Người phát hành
                audience: _configuration["JwtSettings:Issuer"], // Người sử dụng              
                claims: claims,                                  
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
