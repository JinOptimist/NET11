using BusinessLayerInterfaces.UserServices;
using GamerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarServices _carServices;
        public CarController(ICarServices carServices)
        {
            _carServices = carServices;
        }
        public List<IndexCarViewModel> GetIndexCarViewModels()
        {
            var carModels = _carServices
                .GetAll()
                .Select(x => new IndexCarViewModel
                {
                    Id = x.Id,
                    NameCar = x.NameCar,
                    InfoAboutCar = x.InfoAboutCar,
                })
                .ToList();
            return carModels;
        }
    }
}
