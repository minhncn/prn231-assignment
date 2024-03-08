using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.AuthRequest;
using PetShop.Services.Requests.CategoryRequest;
using PetShop.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll(UserFilterRequest filter, PagingRequest pageModel)
        {
            var users = await _userRepository
                .Get()
                .Paging(pageModel.Page, pageModel.PageSize)
                .ToListAsync();
            var filterList = users.AutoFilter(filter);
            return filterList;
        }

        public async Task<User> Create(CreateUserRequest request)
        {
            if (!Enum.TryParse(request.Role, out UserRole role) || !Enum.IsDefined(typeof(UserRole), role))
            {
                throw new ArgumentException("Invalid role");
            }
            if (!Enum.TryParse(request.Status, out UserStatus status) || !Enum.IsDefined(typeof(UserStatus), status))
            {
                throw new ArgumentException("Invalid status");
            }
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Role = role.ToString(),
                Status = status.ToString(),
                Id = Guid.NewGuid(),
            };
            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> Update(UpdateUserRequest request)
        {
            if (!Enum.TryParse(request.Role, out UserRole role) || !Enum.IsDefined(typeof(UserRole), role))
            {
                throw new ArgumentException("Invalid role");
            }
            if (!Enum.TryParse(request.Status, out UserStatus status) || !Enum.IsDefined(typeof(UserStatus), status))
            {
                throw new ArgumentException("Invalid status");
            }
            var user = _userRepository.Get(request.Id);

            if (user == null)
            {
                throw new Exception("This user not found");
            }
            user.Username = request.Username;
            user.Status = status.ToString();
            user.Role = role.ToString();
            user.Email = request.Email;
            user.Password = request.Password;
           
            _userRepository.Update(user);
            return user;
        }

        public async Task<User> Delete(Guid id)
        {
            var user = _userRepository.Get(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Status = Enums.UserStatus.Unavailable.ToString().TrimEnd();

            return user;
        }
    }
}
