using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        public Task<string> Login(string username, string password);
    }
}
