using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class MoviesController : Controller
{
    private readonly IAddMovieServices _addMovieServices;
    private readonly IRemoveServices _removeMovieServices;
    private readonly IShowMovieServices _showMovieServices;

    public MoviesController(IAddMovieServices addMovieServices, IRemoveServices removeMovieServices, IShowMovieServices showMovieServices)
    {
        _addMovieServices = addMovieServices;
        _removeMovieServices = removeMovieServices;
        _showMovieServices = showMovieServices;
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

        _addMovieServices.Add(movieBlm);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        _removeMovieServices.Remove(id);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Show()
    {
        var viewMoviesList = _showMovieServices
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