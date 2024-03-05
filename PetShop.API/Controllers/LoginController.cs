using Microsoft.AspNetCore.Mvc;
using PetShop.Repositories.Interfaces;

namespace PetShop.API.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public LoginController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username or password is empty");
            }
            var token = _authRepository.Login(username, password);
            if(token == null)
            {
                return Unauthorized("Username or password is incorrect");
            }
            return Ok(new {token});
        }
    }
}
