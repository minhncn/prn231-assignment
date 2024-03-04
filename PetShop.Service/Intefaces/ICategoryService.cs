using PetShop.Business.Models;
using PetShop.Services.Requests.CategoryRequest;
using PetShop.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Intefaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();
        public Task<Category> Create(CreateCategoryRequest request);
        public Task<Category> Update(UpdateCategoryRequest request);
        public Task<Category> Delete(Guid id);
    }
}
