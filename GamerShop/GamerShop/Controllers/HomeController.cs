using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class HomeController : Controller
    {
		private IHomeServices _homeServices;

		public HomeController(IHomeServices homeServices)
		{
			_homeServices = homeServices;
		}

		public IActionResult Index()
        {
            var viewModels = _homeServices
                .GetLastLoginUsers()
				.Select(dbUser => new IndexViewModel
                {
                    Id = dbUser.Id,
                    Name = dbUser.Name,
                })
                .ToList();

            return View(viewModels);
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