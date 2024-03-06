using PetShop.Business.Models;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests.AuthRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;

        public UserService(IUserService userService)
        {
            _userService = userService;
        }

        public Task<User> Create(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
