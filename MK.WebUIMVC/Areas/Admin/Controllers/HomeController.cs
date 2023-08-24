using Microsoft.AspNetCore.Mvc;
using MK.WebUIMVC.Models;
using System.Text.Json;

namespace MK.WebUIMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string ara)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5241/api");

            var response = await client.GetAsync($"{client.BaseAddress}/Books");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<BookItem>>(responseRead);

            var booklist = result.data;


            if (!string.IsNullOrEmpty(ara))
            {
                booklist = booklist.Where(x => x.name.Contains(ara)).ToList();
            }
           

            HomeIndexViewModel viewModel = new HomeIndexViewModel();

            viewModel.BookList = booklist;

            return View(viewModel);
        }
    }
}
