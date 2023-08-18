using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class MoviesController : Controller
{
    private readonly IMovieServices _movieServices;
    private readonly IAuthService _authService;

    public MoviesController(IMovieServices movieServices, IAuthService authService)
    {
        _movieServices = movieServices;
        _authService = authService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddMoviesViewModel addMoviesViewModel)
    {
        if (!ModelState.IsValid) return View(addMoviesViewModel);

        var user = _authService.GetCurrentUser();
        var addMovieBlm = new AddMovieBlm
        {
            Title = addMoviesViewModel.Title,
            CreatedDate = DateTime.Now,
            UserId = user.Id
        };

        _movieServices.Add(addMovieBlm);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        _movieServices.Remove(id);

        return RedirectToAction("Show", "Movies");
    }

    [Authorize]
    [HttpGet]
    public IActionResult Show()
    {
        var viewMoviesList = _movieServices
            .GetAllMovies()
            .Select(getMovieBlm => new ShowMovieViewModel
            {
                Id = getMovieBlm.Id,
                Title = getMovieBlm.Title,
                DateCreated = getMovieBlm.DateCreated,
                UserName = getMovieBlm.UserName
            })
            .ToList();

        return View(viewMoviesList);
    }
}