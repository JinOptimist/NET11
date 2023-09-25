using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using GamerShop.Controllers.AuthCustomAttribute;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    [Authorize]
    public class UserController : Controller
	{
		private IUserService _userService;
        private IWebHostEnvironment _webHostEnvironment;
        private Services.IAuthService _authService;

        private IPaginatorService _paginatorService;

        public UserController(IUserService userService, 
            IPaginatorService paginatorService, 
            IWebHostEnvironment webHostEnvironment, 
            Services.IAuthService authService)
        {
            _userService = userService;
            _paginatorService = paginatorService;
            _webHostEnvironment = webHostEnvironment;
            _authService = authService;
        }


        public IActionResult Index(int page = 1, int perPage = 10)
		{
			var viewModel = _paginatorService
				.GetPaginatorViewModel(_userService, MapBlmToViewModel, page, perPage);
			return View(viewModel);
		}

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel profileViewModel)
        {
            var userId = _authService.GetCurrentUser().Id;
            var fileName = $"{userId}.jpg";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath, 
                "img",
                "avatars",
                fileName);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                profileViewModel.Avatar.CopyTo(fs);
            }

            return View();
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

        [AdultOnly]
        public IActionResult LookAtSome18PlusPage()
		{
			return View();
		}

        [AdultOnly]
        public IActionResult DoAtSome18PlusPage()
        {
            return View();
        }

        [AdultOnly]
        public IActionResult FindAtSome18PlusPage()
        {
            return View();
        }
    }
}
