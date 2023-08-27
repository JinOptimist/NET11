using BusinessLayerInterfaces.UserServices;
using GamerShop.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
	public class UserController : Controller
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index(int page = 1, int perPage = 10)
		{
			var dataFromBl = _userService.GetIndexBlm(page, perPage);
			var addtionalPageNumber = dataFromBl.Count % dataFromBl.PerPage == 0 
				? 0 
				: 1;

			var availablePages = Enumerable
				.Range(1, dataFromBl.Count / dataFromBl.PerPage + addtionalPageNumber)
				.ToList();

			var viewModel = new PaginatorUsersViewModel
			{
				Page = dataFromBl.Page,
				PerPage = dataFromBl.PerPage,
				Count = dataFromBl.Count,
				AvailablePages = availablePages,
				Users = dataFromBl
					.Users
					.Select(userBlm => new UserViewModel
					{
						Id = userBlm.Id,
						Name = userBlm.Name,
						FavMovieName = userBlm.FavoriteMovieName,
						AgeInDays = userBlm.AgeInDays,
					})
					.ToList()
			};

			return View(viewModel);
		}
	}
}
