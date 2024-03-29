﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Business.Models;
using PetShop.Services;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.CategoryRequest;
using PetShop.Services.Responses;

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
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Get([FromQuery]CategoryFilterRequest filter,[FromQuery] PagingRequest pagingModel)
        {
            var result = await _categoryService.GetAll(filter, pagingModel);
            if(result != null)
            {
                var paginationResponse = new PaginationResponse<IEnumerable<Category>>(result)
                {
                    Page = pagingModel.Page,
                    PageSize = pagingModel.PageSize,
                };
                return Ok(paginationResponse);
            } else
            {
                return BadRequest("Category not found");
            }
        }
        [HttpPost("categories")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            var result = await _categoryService.Create(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut("categories")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.Update(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("categories/{id}")]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.Delete(id);
            if (result != null)
                return Ok("Delete Success");
            return BadRequest();
        }
    }
}
