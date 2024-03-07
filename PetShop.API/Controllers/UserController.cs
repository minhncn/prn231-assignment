using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Business.Models;
using PetShop.Services.Implements;
using PetShop.Services.Intefaces;
using PetShop.Services.Requests;
using PetShop.Services.Requests.AuthRequest;
using PetShop.Services.Requests.ProductRequest;
using PetShop.Services.Responses;

namespace PetShop.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery]UserFilterRequest filter, [FromQuery] PagingRequest pagingModel)
        {
            var result = await _userService.GetAll(filter, pagingModel);
            if (result != null)
            {
                var paginationResponse = new PaginationResponse<IEnumerable<User>>(result)
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
        [HttpPost("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var result = await _userService.Create(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var result = await _userService.Update(request);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete("users/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            if (result != null)
                return Ok("Delete Success");
            return BadRequest();
        }
    }
}
