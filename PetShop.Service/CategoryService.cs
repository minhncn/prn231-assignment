using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.CategoryRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();
        public Task<Category> Create(CreateCategoryRequest request);
        public Task<Category> Update(UpdateCategoryRequest request);
        public Task<Category> Delete(Guid id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.Get().ToListAsync();
        }

        public async Task<Category> Create(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                //Default is tru
                Status = true
            };
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<Category> Update(UpdateCategoryRequest request)
        {
            var category = _categoryRepository.Get(request.Id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }
            category.Name = request.Name;
            category.Description = request.Description;
            category.Status = false;
            _categoryRepository.Update(category);
            return category;
        }

        public async Task<Category> Delete(Guid id)
        {
            var category = _categoryRepository.Get(id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }
            _categoryRepository.Update(category);

            return category;
        }
    }
}
