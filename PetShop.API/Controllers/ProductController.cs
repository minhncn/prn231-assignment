using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests.ProductRequest;

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
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPost("products")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.Create(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut("products")]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            var result = await _productService.Update(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productService.Delete(id);
            if (result != null)
                return Ok("Delete Success");
            return BadRequest();
        }
    }
}
