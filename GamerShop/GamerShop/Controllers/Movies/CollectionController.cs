using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class CollectionController : Controller
{
    private readonly ICollectionService _collectionService;
    private readonly IMovieServices _movieServices;
    private readonly IAuthService _authService;

    public CollectionController(ICollectionService collectionService, IMovieServices movieServices, IAuthService authService)
    {
        _collectionService = collectionService;
        _movieServices = movieServices;
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Show(int id)
    {
        var collectionBlm = _collectionService.GetCollectionById(id);
        var collectionViewModel = new ShowCollectionViewModel
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
    [Authorize]
    public IActionResult Create()
    {
        
        var createCollectionViewModel = new CreateCollectionViewModel()
        {
            AvailableMovies = _movieServices.GetAvailableMoviesForSelection()
                .Select(s => new ShortMovieViewModelToAddInCollection()
                {
                    Id = s.Id,
                    Title = s.Title,
                    IsSelected = s.IsSelected,
                })
                .ToList(),
        };
        return View(createCollectionViewModel);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(CreateCollectionViewModel createCollectionViewModel)
    {
        if (!createCollectionViewModel.AvailableMovies.Any(movie => movie.IsSelected))
        {
            ModelState.AddModelError("AvailableMovies", "Необходимо выбрать хотя бы один фильм.");
        }
        
        if (ModelState.IsValid)
        {
            var collectionBlmForCreate = new CollectionBlmForCreate()
            {
                Title = createCollectionViewModel.Title,
                Description = createCollectionViewModel.Description,
                MoviesIds = createCollectionViewModel
                    .AvailableMovies
                    .Where(s => s.IsSelected)
                    .Select(s => s.Id)
                    .ToList(),
                Author = _authService.GetCurrentUser()
            };

            _collectionService.CreateCollection(collectionBlmForCreate);
            return RedirectToAction("Show", "Site");
        }


        return View(createCollectionViewModel);
    }
}