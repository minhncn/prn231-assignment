using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetShop.Business.Models;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Implements;
using PetShop.Services.Requests.AuthRequest;

namespace PetShop.API.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService; 
        }
        [HttpPost("login")]
        public Task<LoginResponse?> Login([FromBody]LoginRequest request)
        {
            if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("Username or password is empty");
            }
            var token = _authService.Login(request);
            if(token == null)
            {
                throw new Exception("Username or password is incorrect");
            }
            return token;
        }
    }
}
