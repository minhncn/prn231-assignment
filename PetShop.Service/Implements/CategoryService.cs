using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.CategoryRequest;
using PetShop.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAll(CategoryFilterRequest filter, PagingRequest pageModel)
        {
            var categories = await _categoryRepository
                .Get()
                .Paging(pageModel.Page, pageModel.PageSize)
                .ToListAsync();
            var filterList = categories.AutoFilter(filter);
            return filterList;
        }

        public async Task<Category> Create(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                //Default is true
                Status = Enums.CategoryStatus.Available.ToString().TrimEnd()
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
            if (category.Status == Enums.ProductStatus.Unavailable.ToString().TrimEnd())
            {
                category.Status = Enums.ProductStatus.Available.ToString().TrimEnd();
            }
            else if (category.Status == Enums.ProductStatus.Available.ToString().TrimEnd())
            {
                category.Status = Enums.ProductStatus.Unavailable.ToString().TrimEnd();
            } else
            {
                throw new Exception("Category status is not valid");
            }
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
            category.Status = Enums.CategoryStatus.Unavailable.ToString().TrimEnd();

            return category;
        }
    }
}
