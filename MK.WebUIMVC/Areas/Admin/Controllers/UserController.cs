using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MK.DataAccess.EF.Context;
using MK.Model.Dtos.User;
using MK.Model.Entities;
using MK.WebUIMVC.ApiServices.Interfaces;
using MK.WebUIMVC.Models;
using System.Text.Json;

namespace MK.WebUIMVC.Areas.Admin.Controllers
{



    [Area("Admin")]
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5241/api");

            var response = await client.GetAsync($"{client.BaseAddress}/Users");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<UserItem>>(responseRead);

            var userlist = result.data;
            HomeIndexViewModel viewModel = new HomeIndexViewModel();

            viewModel.UserList = userlist;

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(User item)
        {
            Context context = new Context(); 
           
                context.Users.Add(item);

                context.SaveChanges();
            
            return View();
        }

    }
}
