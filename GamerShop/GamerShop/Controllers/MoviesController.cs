using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

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

        var movieBlm = new MovieBlm()
        {
            Title = addMoviesViewModel.Title,
            CreatedDate = DateTime.Now
        };

        _movieServices.Add(movieBlm);

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
        var user = _authService.GetCurrentUser();
        var viewMoviesList = _movieServices
            .GetAllMovies()
            .Select(movieBlm => new ShowMovieViewModel
            {
                Id = movieBlm.Id,
                Title = movieBlm.Title,
                UserId = user.Id,
                UserName = user.Name
            })
            .ToList();

        return View(viewMoviesList);
    }
}