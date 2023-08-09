
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = PlantsController.PlantsList;
            return View(viewModel);
        }
    }
}