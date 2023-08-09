using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class BooksController : Controller
    {
        public static List<BookViewModel> _books = new List<BookViewModel>();

        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(BookViewModel bookViewModel)
        {
            if (bookViewModel.Name != String.Empty && bookViewModel.Author != String.Empty)
            {
                    _books.Add(bookViewModel);
            }

            return View();
        }

        public IActionResult Books()
        {
            return View(_books);
        }
    }
}
