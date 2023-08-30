using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class UserController : Controller
	{
		private IUserService _userService;

        private IPaginatorService _paginatorService;

        public UserController(IUserService userService, IPaginatorService paginatorService)
        {
            _userService = userService;
            _paginatorService = paginatorService;
        }

        public IActionResult Index(int page = 1, int perPage = 10)
		{
			var viewModel = _paginatorService
				.GetPaginatorViewModel(_userService, MapBlmToViewModel, page, perPage);
			return View(viewModel);
		}

		private UserViewModel MapBlmToViewModel(UserBlm userBlm)
		{
			return new UserViewModel
			{
				Id = userBlm.Id,
				Name = userBlm.Name,
				FavMovieName = userBlm.FavoriteMovieName,
				AgeInDays = userBlm.AgeInDays,
			};
        }
	}
}
