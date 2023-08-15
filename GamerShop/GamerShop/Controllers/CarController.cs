using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class CarController : Controller
    {
        ICarServices _carServices;
        public CarController(ICarServices carServices)
        {
            _carServices = carServices;
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
            var dbCar = new CarBlm()
            {
                NameCar = CarViewModel.NameCar,
                InfoAboutCar = CarViewModel.InfoAboutCar
            };
            _carServices.Save(dbCar);
            return View();
        }

    }
}
