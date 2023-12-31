﻿using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using GamerShop.Models.Auth;
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
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

			var userId = _authService.GetUserIdByNameAndPassword(viewModel.Login, viewModel.Password);
			if (userId == null)
			{
				ModelState.AddModelError(nameof(LoginViewModel.Login), "Не правильный пароль или логин");
                return View(viewModel);
            }

            var userName = _authService.GetUserName(userId.Value);

			AuthOnServer(userId.ToString(), userName);

            return RedirectToAction("Privacy", "Home");
        }
        
        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel authViewModel)
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

            AuthOnServer(dbUser.Id.ToString(), dbUser.Name);

            return RedirectToAction("Privacy", "Home");
		}

		public IActionResult Logout()
		{
            HttpContext.SignOutAsync().Wait();
			return Redirect("/");
        }

        public IActionResult Remove(int id)
        {
            _authService.Remove(id);
            return RedirectToAction("Index", "Home");
        }

        private void AuthOnServer(string userId, string userName)
        {
            var claims = new List<Claim>() {
                new Claim("Id", userId),
                new Claim("Name", userName),
                new Claim("TimeOfLogin", DateTime.Now.Hour + ""),
                new Claim(ClaimTypes.AuthenticationMethod, "WebAuthSmile")
            };

            var identity = new ClaimsIdentity(claims, "WebAuthSmile");

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal).Wait();
        }

    }
}
