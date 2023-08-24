using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MK.Business.Interface;
using MK.Model.Dtos.Book;
using MK.Model.Dtos.User;

namespace MK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserBs _userBs;

        public UsersController(IUserBs userBs)
        {
            _userBs = userBs;
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<UserGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _userBs.GetByIdAsync(id);

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<UserGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<UserGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userBs.GetUsersAsync();

            return SendResponse(response);

        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<UserPostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewUser([FromBody] UserPostDto dto)
        {
            var response = await _userBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.UserID }, response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserPutDto dto)
        {

            var response = await _userBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            var response = await _userBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
