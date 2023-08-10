using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class MoviesController : Controller
{
    public static List<MovieViewModel> Movies = new();

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddMoviesViewModel addMoviesViewModel)
    {
        if (!ModelState.IsValid) return View(addMoviesViewModel);

        var viewModel = new MovieViewModel
        {
            Id = Movies.Any() ? Movies.Max(x => x.Id) + 1 : 1,
            Title = addMoviesViewModel.Title
        };
        Movies.Add(viewModel);
        return RedirectToAction("Show", "Movies");
    }

    public IActionResult Remove(int id)
    {
        var movieToDelete = Movies.SingleOrDefault(movie => movie.Id == id);
        if (movieToDelete != null) Movies.Remove(movieToDelete);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Show()
    {
        var viewMoviesList = Movies;
        return View(viewMoviesList);
    }
}