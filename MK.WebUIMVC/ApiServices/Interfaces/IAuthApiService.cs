using CommonTypesLayer.Utilities;
using MK.Model.Dtos.User;

namespace MK.WebUIMVC.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiResponse<UserGetDto>> GetLoginAsync(UserGetDto getDto);
    }
}
