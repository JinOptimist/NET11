﻿using BusinessLayerInterfaces.BusinessModels.Movies;
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
    public IActionResult Show(string filterCriteria = "Newest")
    {
        var shortCollectionViewModels = _collectionService
            .GetShortMovieCollectionSortedByCriteria(filterCriteria)
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

    [HttpGet]
    public IActionResult UpdateMovieCollectionList(string filterCriteria = "Newest")
    {
        var shortCollectionViewModels = _collectionService
            .GetShortMovieCollectionSortedByCriteria(filterCriteria)
            .Select(shortCollectionBlm => new ShowShortMovieCollectionViewModel
            {
                Id = shortCollectionBlm.Id,
                Title = shortCollectionBlm.Title,
                Description = shortCollectionBlm.Description,
                DateCreated = shortCollectionBlm.DateCreated,
                Rating = shortCollectionBlm.Rating
            })
            .ToList();

        return PartialView("_MovieCollectionList", shortCollectionViewModels);
    }

}