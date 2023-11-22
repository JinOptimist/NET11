using AngleSharp.Common;
using BusinessLayer.UserServices;
using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories.Books;
using GamerShop.Models.Books;
using GamerShop.Models.Recipe;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
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
                Authors = bookBlm.Authors.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.FirstName + " " + x.LastName,
                        Value = x.Id.ToString()
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
        public IActionResult EditBook(int id)
        {
            var editBook = _bookServices.GetAll().First(x=>x.Id == id);
            var selectedAuthors = editBook.Authors;
            var viewModel = new EditBookViewModel()
            {
                Id = editBook.Id,
                Name = editBook.Name,
                YearOfIssue = editBook.YearOfIssue,
                Authors = _authorRepository.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.Id.ToString(),
                    Selected = editBook.Authors.Any(z => z.Id==x.Id)
                }).ToList(),
                SelectedAuthors= editBook.Authors.Select(x => x.Id.ToString()).ToList()
            };
            return View(viewModel);
        }

        public IActionResult EditBook(EditBookViewModel editBookViewModel)
        {
            var bookBlm = new BookPostBlm()
            {
                Id= editBookViewModel.Id,
                Name = editBookViewModel.Name,
                YearOfIssue = editBookViewModel.YearOfIssue,
                Authors = editBookViewModel.SelectedAuthors.Select(x =>
                {
                    var author = _authorRepository.Get(Convert.ToInt32(x));
                    return new ShortAuthorBlm
                    {
                        Id = author.Id,
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    };
                }).ToList()
            };
            _bookServices.Update(bookBlm);
            return RedirectToAction("Books");
        }

        [HttpGet]
        public IActionResult NewBook()
        {
            var a = new NewBookViewModel();
            a.Authors = _authorRepository.GetAll().Select(x => new SelectListItem()
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();

            return View(a);
        }

        [HttpPost]
        public IActionResult NewBook(NewBookViewModel newBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newBookViewModel);
            }

            var bookMemberDb = new BookPostBlm()
            {
                Name = newBookViewModel.Name,
                YearOfIssue = newBookViewModel.YearOfIssue,
                Authors = newBookViewModel.SelectedAuthors.Select(x =>
                {
                    var author = _authorRepository.Get(Convert.ToInt32(x));
                    return new ShortAuthorBlm
                    {
                        Id = author.Id,
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    };
                }).ToList()
        };
            _bookServices.Save(bookMemberDb);
            return RedirectToAction("Books");
        }

        [HttpGet]
        public IActionResult ShowBook(int id)
        {
            var bookBlm = _bookServices.GetAll().First(x => x.Id==id);
            var viewModel = new ShowBookViewModel()
            {
                Id = bookBlm.Id,
                Authors = bookBlm.Authors.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.FirstName + " " + x.LastName,
                        Value = x.Id.ToString()
                    }).ToList(),
                Name = bookBlm.Name,
                YearOfIssue = bookBlm.YearOfIssue
            };

            return View(viewModel);
        }
    }
}
