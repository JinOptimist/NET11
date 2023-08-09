using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class RecipeController : Controller
    {
        public static List<RecipeViewModel> Recipes = new();

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
			Recipes.Add(recipeViewModel);
            return View();
        }

        public IActionResult Show()
        {
	        return View(Recipes);
        }

        public IActionResult Remove(int id)
        { 
	        Recipes.RemoveAt(id);
	        return RedirectToAction("Show");
        }
	}
}
