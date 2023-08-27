using BusinessLayerInterfaces.MovieServices;
using GamerShop.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Movies;

public class CollectionController : Controller
{
    private readonly ICollectionService _collectionService;

    public CollectionController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
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
}