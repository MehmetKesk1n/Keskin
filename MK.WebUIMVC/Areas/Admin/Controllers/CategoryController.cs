using Microsoft.AspNetCore.Mvc;
using MK.WebUIMVC.Models;
using System.Text.Json;

namespace MK.WebUIMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index(string aracat)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5241/api");

            var responseCt = await client.GetAsync($"{client.BaseAddress}/Categories");
            var responseReadCt = await responseCt.Content.ReadAsStringAsync();
            var resultCt = JsonSerializer.Deserialize<ResponseComing<CategoryItem>>(responseReadCt);

            var categorylist = resultCt.data;

           
            if (!string.IsNullOrEmpty(aracat))
            {
                categorylist = categorylist.Where(x => x.categoryName.Contains(aracat)).ToList();
            }



            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.CategoryList = categorylist;



            return View(viewModel);
        }
    }
}
