using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

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
            //comment remove
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
                var dbUser = new User()
                {
                    Name = authViewModel.Login,
                    Password = authViewModel.Password,
                    Birthday = DateTime.Now.AddYears(-1 * authViewModel.Age)
                };

                _userRepository.Save(dbUser);
            }

            return View();
        }
    }
}
