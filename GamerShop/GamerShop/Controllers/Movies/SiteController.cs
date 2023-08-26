using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class SiteController : Controller
{
    private readonly ICollectionService _collectionService;

    public SiteController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }

    [HttpGet]
    public IActionResult Show()
    {
        var shortCollectionViewModels = _collectionService
            .GetShortCollectionSortedByDate()
            .Select(shortCollectionBlm => new ShortCollectionViewModel
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