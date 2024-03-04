using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.ProductRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<Product> Create(CreateProductRequest request);
        public Task<Product> Update(UpdateProductRequest request);
        public Task<Product> Delete(Guid id);
    }
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
                Status = true
            };
            return _productRepository.CreateAsync(product);
        }

        public Task<Product> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
