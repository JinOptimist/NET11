using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
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

        var viewModel = new Movie
        {
            Title = addMoviesViewModel.Title,
            CreatedDate = DateTime.Now
        };

        _movieRepository.Save(viewModel);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        _movieRepository.Remove(id);

        return RedirectToAction("Show", "Movies");
    }

    [HttpGet]
    public IActionResult Show()
    {
        var viewMoviesList = _movieRepository
            .GetAll()
            .Select(dbMovie => new ShowMovieViewModel
            {
                Id = dbMovie.Id,
                Title = dbMovie.Title
            })
            .ToList();

        return View(viewMoviesList);
    }
}