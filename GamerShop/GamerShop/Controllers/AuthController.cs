using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class AuthController : Controller
    {
        public static List<string> _names = new List<string>();

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

            if (authViewModel.Password == "123")
            {
                _names.Add(authViewModel.Login);
            }

            return View();
        }

    }
}
