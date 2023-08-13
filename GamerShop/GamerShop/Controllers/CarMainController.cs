using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class CarMainController : Controller
    {
        ICarRepository _carRepository;
        public CarMainController(ICarRepository carRepository, ILogger<HomeController> logger)
        {
            _carRepository = carRepository;

        }

        public IActionResult Index()
        {
            var viewModel = _carRepository
                .GetAll()
                .Select(dbuser => new IndexCarViewModel
                {
                    Id = dbuser.Id,
                    NameCar = dbuser.NameCar,
                    InfoAboutCar = dbuser.InfoAboutCar,
                })

                .ToList();
            return View(viewModel);
        }
        public IActionResult Remove(int id)
        {
            _carRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
