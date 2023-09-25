using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieServices;

    public MovieController(IMovieRepository movieServices)
    {
        _movieServices = movieServices;
    }

    [HttpGet]
    public IActionResult Show(int id)
    {
        var movieBlm = _movieServices.GetMovieBlm(id);
        var showMovieViewModel = new ShowMovieViewModel
        {
            Title = movieBlm.Title,
            Description = movieBlm.Description,
            ReleaseYear = movieBlm.ReleaseYear,
            Director = movieBlm.Director,
            Rating = movieBlm.Rating,
            Country = movieBlm.Country,
            Duration = movieBlm.Duration,
            Genres = movieBlm.Genres
        };
        return View(showMovieViewModel);
    }
}