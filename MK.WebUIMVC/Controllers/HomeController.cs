using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MK.WebUIMVC.Models;
using System.Text.Json;

namespace MK.WebUIMVC.Controllers
{
    public class HomeController : Controller
    {

        
        public async Task<IActionResult> Index(string ara,string aracat)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5241/api");

            var response = await client.GetAsync($"{client.BaseAddress}/Books");
            var responseRead = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseComing<BookItem>>(responseRead);


            var responseCt = await client.GetAsync($"{client.BaseAddress}/Categories");
            var responseReadCt = await responseCt.Content.ReadAsStringAsync();
            var resultCt = JsonSerializer.Deserialize<ResponseComing<CategoryItem>>(responseReadCt);

            var booklist = result.data;
            var categorylist = resultCt.data;
            BookItem bookitem = new BookItem();
            if (!string.IsNullOrEmpty(ara))
            {
                booklist = booklist.Where(x=>x.name.Contains(ara)).ToList();
            }
            if (!string.IsNullOrEmpty(aracat))
            {
                booklist = booklist.Where(x => x.categoryName.Contains(aracat)).ToList();
            }

            //if (id != null)
            //{
            //    var booklistl = booklist.Where(x => x.categoryID == id);
            //    //return View(booklistl);
            //}
               






                HomeIndexViewModel viewModel = new HomeIndexViewModel();

            viewModel.BookList = booklist;
            viewModel.CategoryList = categorylist;

           

            return View(viewModel);
        }
      


    }
}