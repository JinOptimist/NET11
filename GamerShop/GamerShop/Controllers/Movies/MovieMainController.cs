using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class MovieMainController : Controller
{
    private readonly IMovieCollectionService _collectionService;

    public MovieMainController(IMovieCollectionService collectionService)
    {
        _collectionService = collectionService;
    }

    [HttpGet]
    public IActionResult Show()
    {
        var shortCollectionViewModels = _collectionService
            .GetShortMovieCollectionSortedByDate()
            .Select(shortCollectionBlm => new ShowShortMovieCollectionViewModel
            {
                Id = shortCollectionBlm.Id,
                Title = shortCollectionBlm.Title,
                Description = shortCollectionBlm.Description,
                DateCreated = shortCollectionBlm.DateCreated,
                Rating = shortCollectionBlm.Rating
            })
            .ToList();

        return View(shortCollectionViewModels);
    }
}