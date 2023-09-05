using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using GamerShop.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class BooksController : Controller
    {
        private IBookServices _bookServices;
        private IAuthService _authService;

        public BooksController(IBookServices bookServices, IAuthService authService)
        {
            _bookServices = bookServices;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Books()
        {
            var viewModel = _bookServices
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
            _bookServices.Remove(id);
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

            var bookMemberDb = new BookPostBlm()
            {
                Author = newBookViewModel.Author,
                Name = newBookViewModel.Name,
                YearOfIssue = newBookViewModel.YearOfIssue
            };

            _bookServices.Save(bookMemberDb);
            return RedirectToAction("Books");
        }
    }
}
