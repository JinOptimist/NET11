using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieServices _movieServices;

    public MoviesController(IMovieServices movieServices)
    {
        _movieServices = movieServices;
    }

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

    [HttpGet]
    public IActionResult Show()
    {
        var viewMoviesList = _movieServices
            .GetAllMovies()
            .Select(movieBlm => new ShowMovieViewModel
            {
                Id = movieBlm.Id,
                Title = movieBlm.Title
            })
            .ToList();

        return View(viewMoviesList);
    }
}