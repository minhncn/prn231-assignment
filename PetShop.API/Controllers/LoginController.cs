using Microsoft.AspNetCore.Mvc;
using PetShop.Business.Models;
using PetShop.Repositories.Interfaces;
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
        public IActionResult Login([FromBody]LoginRequest request)
        {
            if(string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username or password is empty");
            }
            var token = _authService.Login(request);
            if(token == null)
            {
                return Unauthorized("Username or password is incorrect");
            }
            return Ok(token);
        }
    }
}
