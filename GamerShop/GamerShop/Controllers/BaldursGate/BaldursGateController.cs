using DALInterfaces.Models;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models.BaldursGate;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;

namespace GamerShop.Controllers.BaldursGate
{
    public class BaldursGateController : Controller

    {
        private IBgServices _bgServices;

        public BaldursGateController(IBgServices bgServices)
        {
            _bgServices = bgServices;
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
                })
                .ToList());
        }

        [HttpPost]
        public IActionResult CharacterCreation(BaldursGateModel BgModel)

        {
            _bgServices.Save(new BaldursGateBml()
            {
                Bone = BgModel.Bone,
                Name = BgModel.Name,
                Class = BgModel.Class,
                Races = BgModel.Races,
                Subrace = BgModel.Subrace,
                Оrigin = BgModel.Оrigin
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
