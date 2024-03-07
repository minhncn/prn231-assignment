using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Requests.AuthRequest
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Status { get; set; }

        public string Role { get; set; } = null!;
    }
}
