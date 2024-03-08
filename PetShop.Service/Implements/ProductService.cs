using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.ProductRequest;
using PetShop.Services.Utils;

namespace PetShop.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> Create(CreateProductRequest request)
        {
            if (request.Name.Length > 255 || request.Status.Length > 20)
            {
                Constants.ProductMessages.OutOfBound.ToString();
            }
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            if (category == null)
            {
                throw new Exception(Constants.ProductMessages.NotFoundCategoryId.ToString());
            }
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Status = Enums.ProductStatus.Available.ToString().TrimEnd()
            };
            return await _productRepository.CreateAsync(product);
        }

        public async Task<Product> Delete(Guid id)
        {
            var product = _productRepository.Get(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.Status = Enums.ProductStatus.Unavailable.ToString().TrimEnd();
            return product;
        }

        public async Task<List<Product>> GetAll(ProductFilterRequest filter, PagingRequest pageModel)
        {
            var products = await _productRepository
                .Get()
                .Paging(pageModel.Page, pageModel.PageSize)
                .ToListAsync();
            var filterList = products.AutoFilter(filter);
            return filterList;
        }

        public async Task<Product> Update(UpdateProductRequest request)
        {
            if (request.Name.Length > 255 || request.Status.Length > 20)
            {
                Constants.ProductMessages.OutOfBound.ToString();
            }
            var product = _productRepository.Get(request.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            else
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
                if (product.Status == Enums.ProductStatus.Unavailable.ToString().TrimEnd())
                {
                    product.Status = Enums.ProductStatus.Available.ToString().TrimEnd();
                }
                else if (product.Status == Enums.ProductStatus.Available.ToString().TrimEnd())
                {
                    product.Status = Enums.ProductStatus.Unavailable.ToString().TrimEnd();
                }
                return _productRepository.Update(product);
            }
        }
    }
}
