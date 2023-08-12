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
            var viewModel = _userRepository
                .GetAll()
                .Select(x => x.Name)
                .ToList();

            return View(viewModel);
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