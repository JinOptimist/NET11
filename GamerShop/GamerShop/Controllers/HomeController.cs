using BusinessLayerInterfaces.UserServices;
using GamerShop.Models;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class HomeController : Controller
    {
		private IHomeServices _homeServices;
        private Services.IAuthService _authService;

		public HomeController(IHomeServices homeServices, Services.IAuthService authService)
		{
			_homeServices = homeServices;
			_authService = authService;
		}

		public IActionResult Index()
        {
            var viewModels = _homeServices
                .GetLastLoginUsers()
				.Select(blmUser => new IndexViewModel
                {
                    Id = blmUser.Id,
                    Name = blmUser.Name,
                    FavoriteMovieName = blmUser.FavoriteMovieName
                })
                .ToList();

            return View(viewModels);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            var user = _authService.GetCurrentUser();

			var viewModel = new PrivacyViewModel
            {
                DayOfWeek = DateTime.Now.DayOfWeek,
                Name = user.Name
			};

            return View(viewModel);
        }
    }
}