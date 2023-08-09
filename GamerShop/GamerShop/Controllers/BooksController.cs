using DALInterfaces.Models;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookViewModel);
            }
            var dbBook = new Book()
            {
                Name = bookViewModel.Name,
                Author = bookViewModel.Author,
                YearOfIssue = bookViewModel.YearOfIssue
            };
            
            _bookRepository.Save(dbBook);

            return View();
        }

        public IActionResult Books()
        {
            var viewModel = _bookRepository.GetAll()
                .Select(x => x.Name)
                .ToList();
            return View(viewModel);
        }
    }
}
