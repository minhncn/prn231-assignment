using Microsoft.AspNetCore.Mvc;
using PetShop.Services;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.CategoryRequest;

namespace PetShop.API.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAll();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPost("categories")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            var result = await _categoryService.Create(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut("categories")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.Update(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.Delete(id);
            if (result != null)
                return Ok("Delete Success");
            return BadRequest();
        }
    }
}
