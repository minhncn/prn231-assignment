using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests.ProductRequest;

namespace PetShop.Services.Implements
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Create(CreateProductRequest request)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Status = Enums.ProductStatus.Available.ToString().TrimEnd()
            };
            return _productRepository.CreateAsync(product);
        }

        public async Task<Product> Delete(Guid id)
        {
            var product = _productRepository.Get(id);
            if(product == null)
            {
                throw new Exception("Product not found");
            } 
            product.Status = Enums.ProductStatus.Unavailable.ToString().TrimEnd();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.Get().ToListAsync();
        }

        public async Task<Product> Update(UpdateProductRequest request)
        {
            var product = _productRepository.Get(request.Id);
            if(product == null)
            {
                throw new Exception("Product not found");
            } else
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
                if(product.Status == Enums.ProductStatus.Unavailable.ToString().TrimEnd())
                {
                    product.Status = Enums.ProductStatus.Available.ToString().TrimEnd();
                } else if(product.Status == Enums.ProductStatus.Available.ToString().TrimEnd())
                {
                    product.Status = Enums.ProductStatus.Unavailable.ToString().TrimEnd();
                }
                return _productRepository.Update(product);
            }
        }
    }
}
