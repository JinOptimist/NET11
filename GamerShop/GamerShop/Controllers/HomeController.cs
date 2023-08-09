using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var viewModels = _userRepository
                .GetAll()
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