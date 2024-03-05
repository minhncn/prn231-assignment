using PetShop.Business.Models;
using PetShop.Services.Requests.AuthRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(LoginRequest request);
    }
}
