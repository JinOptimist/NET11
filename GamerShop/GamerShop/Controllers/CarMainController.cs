using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class CarMainController : Controller
    {
        ICarServices _carServices;
        public CarMainController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            var viewModel = _carServices
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
            _carServices.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
