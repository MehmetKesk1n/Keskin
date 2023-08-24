using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MK.Business.Interface;
using MK.Model.Dtos.Category;

namespace MK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBs _categoryBs;
        public CategoriesController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CategoryGetDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _categoryBs.GetByIDAsync(id, "Books");

            return SendResponse(response);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryBs.GetCategoryAsync("Books");

            return SendResponse(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CategoryPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CategoryPostDto>))]
        [HttpPost]
        public async Task<IActionResult> SaveNewCategory([FromBody] CategoryPostDto dto)
        {

            var response = await _categoryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.CategoryID }, response.Data);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {

            var response = await _categoryBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            var response = await _categoryBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}   
