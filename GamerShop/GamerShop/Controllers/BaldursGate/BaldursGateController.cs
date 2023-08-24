using GamerShop.Models.BaldursGate;
using Microsoft.AspNetCore.Mvc;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;
using GamerShop.Services;

namespace GamerShop.Controllers.BaldursGate
{
	public class BaldursGateController : Controller

    {
        private IBgServices _bgServices;
        private IAuthService _authService;

        public BaldursGateController(IBgServices bgServices, IAuthService authService)
        {
            _bgServices = bgServices;
            _authService =  authService;
        }



        [HttpGet]
        public IActionResult CharacterCreation()
        {
            return View();
        }
        public IActionResult CharacterList()
        {
            //Я овощ
            return View(_bgServices
                .GetAllHero()
                .Select(x => new BaldursGateModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Class = x.Class,
                    Creator_Name = x.CreatorId.Name,
                })
                .ToList());
        }

        [HttpPost]
        public IActionResult CharacterCreation(BaldursGateModel BgModel)
        {
            var user = _authService.GetCurrentUser();
            _bgServices.Save(new BaldursGateBml()
            {
                Bone = BgModel.Bone,
                Name = BgModel.Name,
                Class = BgModel.Class,
                Races = BgModel.Races,
                Subrace = BgModel.Subrace,
                Оrigin = BgModel.Оrigin,
                CreatorId = user,
            });


            return View();
        }
        public IActionResult Remove(int id)
        {
            _bgServices.Remove(id);
            return RedirectToAction("CharacterList", "BaldursGate");
        }

    }
}
