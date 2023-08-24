using CommonTypesLayer.Utilities;
using MK.Model.Dtos.User;
using MK.WebUIMVC.ApiServices.Interfaces;
using System.Text.Json;

namespace MK.WebUIMVC.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _htttpClient;

        public AuthApiService(HttpClient htttpClient)
        {
            _htttpClient = htttpClient;
        }

        public async Task<ApiResponse<UserGetDto>> GetLoginAsync(UserGetDto getDto)
        {
            HttpResponseMessage responseMessage = await _htttpClient.PostAsJsonAsync("User/Login", getDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data =await responseMessage.Content.ReadAsStringAsync();
                var result =  JsonSerializer.Deserialize<ApiResponse<UserGetDto>>(data);
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}

