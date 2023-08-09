using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = BaldursGateController._BGclass;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            var viewModel = new PrivacyViewModel
            {
                DayOfWeek = DateTime.Now.DayOfWeek,
                Name = "Smile"
            };

            return View(viewModel);
        }
    }
}