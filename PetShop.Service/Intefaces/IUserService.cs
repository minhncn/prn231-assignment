using PetShop.Business.Models;
using PetShop.Services.Requests.AuthRequest;
using PetShop.Services.Requests.ProductRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Intefaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> Create(CreateUserRequest request);
        public Task<User> Update(UpdateUserRequest request);
        public Task<User> Delete(Guid id);
    }
}
