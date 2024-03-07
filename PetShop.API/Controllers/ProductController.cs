using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Business.Models;
using PetShop.Services.Implements;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.ProductRequest;
using PetShop.Services.Responses;

namespace PetShop.API.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        [Authorize(Roles = "Admin, Staff, User")]
        public async Task<IActionResult> Get([FromQuery]ProductFilterRequest filter, [FromQuery] PagingRequest pagingModel)
        {
            var result = await _productService.GetAll(filter, pagingModel);
            if (result != null)
            {
                var paginationResponse = new PaginationResponse<IEnumerable<Product>>(result)
                {
                    Page = pagingModel.Page,
                    PageSize = pagingModel.PageSize,
                };
                return Ok(paginationResponse);
            }
            else
            {
                return BadRequest("Category not found");
            }
        }
        [HttpPost("products")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.Create(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut("products")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            var result = await _productService.Update(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("products/{id}")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productService.Delete(id);
            if (result != null)
                return Ok("Delete Success");
            return BadRequest();
        }
    }
}
