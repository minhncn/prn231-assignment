using PetShop.Business.Models;
using PetShop.Services.Requests;
using PetShop.Services.Requests.ProductRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Intefaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll(PagingRequest pageModel);
        public Task<Product> Create(CreateProductRequest request);
        public Task<Product> Update(UpdateProductRequest request);
        public Task<Product> Delete(Guid id);
    }
}
