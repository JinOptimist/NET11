using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using GamerShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerShop.Controllers
{
    public class AuthController : Controller
    {
		private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(authViewModel);
            }

			var userId = _authService.GetUserIdByNameAndPassword(authViewModel.Login, authViewModel.Password);
			if (userId == null)
			{
				ModelState.AddModelError(nameof(AuthViewModel.Login), "Не правильный пароль или логин");
                return View(authViewModel);
            }

			var claims = new List<Claim>() {
				new Claim("Id", userId.ToString()),
				new Claim("TimeOfLogin", DateTime.Now.Hour + ""),
				new Claim(ClaimTypes.AuthenticationMethod, "WebAuthSmile")
			};

            var identity = new ClaimsIdentity(claims, "WebAuthSmile");

            var principal = new ClaimsPrincipal(identity);

			HttpContext.SignInAsync(principal).Wait();

            return View();
        }

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(AuthViewModel authViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(authViewModel);
			}

			var dbUser = new User()
			{
				Name = authViewModel.Login,
				Password = authViewModel.Password,
				Birthday = DateTime.Now
			};

			_authService.Save(dbUser);

			return View();
		}

		public IActionResult Remove(int id)
        {
            _authService.Remove(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
