using Azure.Core;
using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetShop.Business.Models;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Implements;
using PetShop.Services.Requests.AuthRequest;
using PetShop.Services.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse?> Login(LoginRequest loginRequest)
        {
            Expression<Func<User, bool>> searchFilter = p =>
                p.Username.Equals(loginRequest.Username) &&
                p.Password.Equals(loginRequest.Password);

            var user = _userRepository.Get(searchFilter).FirstOrDefault();

            if (user == null) return null;

            var token = JwtUtil.GenerateJwtToken(user);

            var loginResponse = new LoginResponse()
            {
                AccessToken = token,
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Status = user.Status,
                Role = user.Role,
            };

            return loginResponse;
        }
    }
}
