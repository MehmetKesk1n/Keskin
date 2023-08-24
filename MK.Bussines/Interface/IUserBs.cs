using CommonTypesLayer.Utilities;
using MK.Model.Dtos.Book;
using MK.Model.Dtos.User;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Interface
{
    public interface IUserBs
    {
        Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList);
        Task<ApiResponse<List<UserGetDto>>> GetLoginAsync(UserGetDto getDto);
        Task<ApiResponse<UserGetDto>> GetByIdAsync(int userId, params string[] includeList);
        Task<ApiResponse<User>> InsertAsync(UserPostDto user);
        Task<ApiResponse<NoData>> UpdateAsync(UserPutDto user);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
