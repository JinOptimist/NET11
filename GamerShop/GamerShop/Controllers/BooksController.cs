using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models.Books;
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
        public IActionResult Books()
        {
            var viewModel = _bookRepository
                .GetAll()
                .Select(dbMember => new BookViewModel
                {
                    Id = dbMember.Id,
                    Author = dbMember.Author,
                    Name = dbMember.Name,
                    YearOfIssue = dbMember.YearOfIssue
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.Remove(id);
            return RedirectToAction("Books");
        }

        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(NewBookViewModel newBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newBookViewModel);
            }

            var bookMemberDb = new Book()
            {
                Author = newBookViewModel.Author,
                Name = newBookViewModel.Name,
                YearOfIssue = newBookViewModel.YearOfIssue
            };

            _bookRepository.Save(bookMemberDb);
            return RedirectToAction("Books");
        }
    }
}
