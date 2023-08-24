using MK.Model.Dtos.User;

namespace MK.WebUIMVC.ApiServices.Interfaces
{
    public interface IUserApiServices
    {
        Task<List<UserGetDto>> GetUsersAsync();
    }
}
