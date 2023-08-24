using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MK.Business.Interface;
using MK.Model.Dtos.Book;

namespace MK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookBs _bookBs;

        public BooksController(IBookBs bookBs)
        {
            _bookBs = bookBs;
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<BookGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<BookGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _bookBs.GetByIdAsync(id, "Category");

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<BookGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookBs.GetProductsAsync("Category");

            return SendResponse(response);

        }




        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<BookGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<BookGetDto>>))]
        #endregion
        [HttpGet("getbyprice")]
        public async Task<IActionResult> GetByPriceRange([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _bookBs.GetProductsByPriceAsync(min, max, "Category");
            return SendResponse(response);

        }
      
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<BookPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<BookPostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewBook([FromBody] BookPostDto dto)
        {
            var response = await _bookBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.BookID }, response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookPutDto dto)
        {

            var response = await _bookBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromQuery] int id)
        {
            var response = await _bookBs.DeleteAsync(id);

            return SendResponse(response);
        }


    }
}
