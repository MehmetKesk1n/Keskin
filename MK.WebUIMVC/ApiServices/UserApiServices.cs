using CommonTypesLayer.Utilities;
using MK.Model.Dtos.User;
using MK.WebUIMVC.ApiServices.Interfaces;

namespace MK.WebUIMVC.ApiServices
{
    public class UserApiServices : IUserApiServices
    {
        private HttpClient _httpClient;

        public UserApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserGetDto>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("Users");
            if(!response.IsSuccessStatusCode) 
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UserGetDto>>>();
            return responseSuccess.Data.ToList();

        }
    }
}
