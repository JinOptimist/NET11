using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Controllers.Movies;

public class MovieCollectionController : Controller
{
    private readonly IMovieCollectionService _collectionService;
    private readonly IMovieServices _movieServices;
    private readonly IAuthService _authService;
    private readonly IPaginatorService _paginatorService;

    public MovieCollectionController(IMovieCollectionService collectionService, IMovieServices movieServices,
        IAuthService authService, IPaginatorService paginatorService)
    {
        _collectionService = collectionService;
        _movieServices = movieServices;
        _authService = authService;
        _paginatorService = paginatorService;
    }

    [HttpGet]
    public IActionResult Show(int id)
    {
        var collectionBlm = _collectionService.GetMovieCollectionById(id);
        var collectionViewModel = new ShowMovieCollectionViewModel
        {
            Id = collectionBlm.Id,
            Title = collectionBlm.Title,
            Description = collectionBlm.Description,
            DateCreated = collectionBlm.DateCreated,
            AuthorName = collectionBlm.AuthorName,
            Movies = collectionBlm.Movies,
            Rating = collectionBlm.Rating
        };

        return View(collectionViewModel);
    }

    [HttpGet]
    public IActionResult ShowAll(int page = 1, int perPage = 5)
    {
        var paginatorViewModel = _paginatorService
            .GetPaginatorViewModel(_collectionService, MapBlmToViewModel, page, perPage);
        
        return View(paginatorViewModel);
    }
    private ShowShortMovieCollectionViewModel MapBlmToViewModel(ShortMovieCollectionBlm shortMovieCollectionBlm)
    {
        return new ShowShortMovieCollectionViewModel
        {
            Id = shortMovieCollectionBlm.Id,
            Title = shortMovieCollectionBlm.Title,
            Description = shortMovieCollectionBlm.Description,
            DateCreated = shortMovieCollectionBlm.DateCreated,
            Rating = shortMovieCollectionBlm.Rating
        };
    }

    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        var createCollectionViewModel = new CreateMovieCollectionViewModel
        {
            AvailableMovies = _movieServices.GetAvailableMoviesForSelection()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Title,
                    Selected = false
                })
                .ToList()
        };
        return View(createCollectionViewModel);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(CreateMovieCollectionViewModel createMovieCollectionViewModel)
    {
        if (!createMovieCollectionViewModel.AvailableMovies.Any(movie => movie.Selected))
            ModelState.AddModelError("AvailableMovies", "Необходимо выбрать хотя бы один фильм.");

        if (!ModelState.IsValid) return View(createMovieCollectionViewModel);

        var movieCollectionBlmForCreate = new MovieCollectionBlmForCreate
        {
            Title = createMovieCollectionViewModel.Title,
            Description = createMovieCollectionViewModel.Description,
            MoviesIds = createMovieCollectionViewModel
                .AvailableMovies
                .Where(s => s.Selected)
                .Select(s => int.Parse(s.Value))
                .ToList(),
            Author = _authService.GetCurrentUser()
        };

        _collectionService.CreateMovieCollection(movieCollectionBlmForCreate);
        return RedirectToAction("Show", "MovieMain");
    }
}