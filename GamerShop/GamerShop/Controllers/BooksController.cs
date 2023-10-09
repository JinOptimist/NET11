using AngleSharp.Common;
using BusinessLayer.UserServices;
using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories.Books;
using GamerShop.Models.Books;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GamerShop.Controllers
{
    public class BooksController : Controller
    {
        private IBookServices _bookServices;
        private IPaginatorService _paginatorService;
        private IAuthorRepository _authorRepository;

        public BooksController(IBookServices bookServices, IPaginatorService paginatorService, IAuthorRepository authorRepository)
        {
            _bookServices = bookServices;
            _paginatorService = paginatorService;
            _authorRepository= authorRepository;
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
                Authors = bookBlm.AuthorsIds.Select(x =>
                    new SelectListItem()
                    {
                        Text = _authorRepository.Get(x).FirstName + " " + _authorRepository.Get(x).LastName,
                        Value = x.ToString(),
                        Selected = false
                    }).ToList(),
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
            var a = new NewBookViewModel();
            a.Authors = _authorRepository.GetAll().ToList().ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.Id.ToString(),
                    Selected = false
                };
            });

            return View(a);
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
                AuthorsIds = newBookViewModel.Authors.Select(x => Convert.ToInt32(x.Value)).ToList(),
                Name = newBookViewModel.Name,
                YearOfIssue = newBookViewModel.YearOfIssue
            };
            _bookServices.Save(bookMemberDb);
            return RedirectToAction("Books");
        }
    }
}
