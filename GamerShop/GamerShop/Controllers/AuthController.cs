using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerShop.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

			var user = _userRepository.GetUserByNameAndPassword(authViewModel.Login, authViewModel.Password);
			if (user == null)
			{
				throw new Exception("You try hack me");
			}

			var claims = new List<Claim>() {
				new Claim("Id", user.Id.ToString()),
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
				Birthday = DateTime.Now.AddYears(-1 * authViewModel.Age)
			};

			_userRepository.Save(dbUser);

			return View();
		}

		public IActionResult Remove(int id)
        {
            _userRepository.Remove(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
