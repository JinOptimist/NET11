using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.RecipeServices;
using GamerShop.Models;
using GamerShop.Models.Recipe;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class RecipeController : Controller
    {

        private readonly IRecipeServices _recipeServices;
        private readonly IAuthService _authService;

        public RecipeController(IRecipeServices recipeServices, IAuthService authService)
        {
            _recipeServices = recipeServices;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RecipeViewModel recipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUserId = _authService.GetCurrentUser().Id;
            var recipeBlm = new RecipeBlm()
            {
                Title = recipeViewModel.Title,
                Description = recipeViewModel.Title,
                Instructions = recipeViewModel.Instructions,
                CookingTime = recipeViewModel.CookingTime,
                PreparationTime = recipeViewModel.PreparationTime,
                Servings = recipeViewModel.Servings,
                DifficultyLevel = recipeViewModel.DifficultyLevel,
                Cuisine = recipeViewModel.Cuisine,
                CreatedByUserId = currentUserId,
                CreatedOn = DateTime.Now
            };

            _recipeServices.Save(recipeBlm);
            return RedirectToAction("Index");
		}

        [Authorize]
        [HttpGet]
        public IActionResult Show()
        {
            var currentUserId = _authService.GetCurrentUser().Id;
            var viewModel = _recipeServices.GetAll().Select(x => new ShowRecipeViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Title,
                Instructions = x.Instructions,
                CookingTime = x.CookingTime,
                PreparationTime = x.PreparationTime,
                Servings = x.Servings,
                DifficultyLevel = x.DifficultyLevel,
                Cuisine = x.Cuisine,
                IsFavorite = _recipeServices.GetFavoriteByUser(currentUserId).Any(u => u.Id == x.Id)
            }).ToList();

            return View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            _recipeServices.Remove(id);
            return RedirectToAction("Show");
        }

        public IActionResult RemoveFavorite(int recipeId)
        {
            var currentUserId = _authService.GetCurrentUser().Id;
	        _recipeServices.RemoveFavorite(recipeId, currentUserId);
	        return RedirectToAction("Favorites");
        }

        public IActionResult AddFavorite(int recipeId)
        {
	        var currentUserId = _authService.GetCurrentUser().Id;
	        _recipeServices.AddFavorite(recipeId, currentUserId);
	        return RedirectToAction("Show");
        }

		[Authorize]
        [HttpGet]
		public IActionResult Favorites()
        {
	        var currentUserId = _authService.GetCurrentUser().Id;
	        var viewModel = _recipeServices.GetFavoriteByUser(currentUserId).Select(x => new FavoriteRecipeViewModel()
	        {
		        Id = x.Id,
		        Title = x.Title,
		        Description = x.Title,
		        Instructions = x.Instructions,
		        CookingTime = x.CookingTime,
		        PreparationTime = x.PreparationTime,
		        Servings = x.Servings,
		        DifficultyLevel = x.DifficultyLevel,
		        Cuisine = x.Cuisine
	        }).ToList();

	        return View(viewModel);
        }
    }
}
