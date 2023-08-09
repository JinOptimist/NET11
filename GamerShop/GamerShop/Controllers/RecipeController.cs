using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class RecipeController : Controller
    {

        private IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
	        _recipeRepository = recipeRepository;
        }

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

	        var dbRecipe = new Recipe()
	        {
		        Title = recipeViewModel.Title,
		        Description = recipeViewModel.Title,
		        Instructions = recipeViewModel.Instructions,
		        CookingTime = recipeViewModel.CookingTime,
		        PreparationTime = recipeViewModel.PreparationTime,
		        Servings = recipeViewModel.Servings,
		        DifficultyLevel = recipeViewModel.DifficultyLevel,
		        Cuisine = recipeViewModel.Cuisine
	        };

			_recipeRepository.Save(dbRecipe);
            return View();
        }

        public IActionResult Show()
        {
	        var viewModel = _recipeRepository.GetAll().Select(x => new RecipeViewModel()
	        {
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

        public IActionResult Remove(int id)
        { 
	        _recipeRepository.Remove(id);
	        return RedirectToAction("Show");
        }
	}
}
