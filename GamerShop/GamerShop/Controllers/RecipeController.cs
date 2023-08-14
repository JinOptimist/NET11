using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.RecipeServices;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class RecipeController : Controller
    {

        private IRecipeServices _recipeServices;

        public RecipeController(IRecipeServices recipeServices)
        {
            _recipeServices = recipeServices;
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

            var recipeBlm = new RecipeBlm()
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

            _recipeServices.Save(recipeBlm);
            return View();
        }

        public IActionResult Show()
        {
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
                Cuisine = x.Cuisine
            }).ToList();

            return View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            _recipeServices.Remove(id);
            return RedirectToAction("Show");
        }
    }
}
