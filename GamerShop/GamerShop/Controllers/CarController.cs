using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class CarController : Controller
    {
        ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CarViewModel CarViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(CarViewModel);
            }
            var dbCar = new Car()
            {         
                NameCar = CarViewModel.NameCar,
                InfoAboutCar = CarViewModel.InfoAboutCar
            };
            _carRepository.Save(dbCar);
            return View();
        }
       
    }
}
