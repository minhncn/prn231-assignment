using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Requests.AuthRequest
{
    public class LoginRequest
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string? Role { get; set; }
    }
}
