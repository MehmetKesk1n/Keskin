using Microsoft.AspNetCore.Mvc;
using MK.WebUIMVC.Models;
using System.Text.Json;

namespace MK.WebUIMVC.Controllers
{
    public class SepetController : Controller
    {
        public async Task<IActionResult> Sepet(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5241/api");

            var response = await client.GetAsync($"{client.BaseAddress}/Books");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<BookItem>>(responseRead);

            var booklist = result.data;

            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.BookList = booklist;


            
            

            return View(viewModel);
        }
    }
}
