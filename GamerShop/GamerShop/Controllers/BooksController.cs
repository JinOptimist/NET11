using BusinessLayer.UserServices;
using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using GamerShop.Models.Books;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class BooksController : Controller
    {
        private IBookServices _bookServices;
        private Services.IAuthService _authService;
        private IPaginatorService _paginatorService;

        public BooksController(IBookServices bookServices, IPaginatorService paginatorService)
        {
            _bookServices = bookServices;
            _paginatorService = paginatorService;
        }

        [HttpGet]
        public IActionResult Books(int page = 1, int perPage = 5)
        {
                var viewModel = _paginatorService
                    .GetPaginatorViewModel(_bookServices, MapBlmToViewModel, page, perPage);
            return View(viewModel);
        }

        private BookViewModel MapBlmToViewModel(BookGetBlm bookBlm)
        {
            return new BookViewModel
            {
                Id = bookBlm.Id,
                Author = bookBlm.Author,
                Name = bookBlm.Name,
                YearOfIssue = bookBlm.YearOfIssue
            };
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
