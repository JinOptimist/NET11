using GamerShop.Models.BaldursGate;
using Microsoft.AspNetCore.Mvc;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.BG;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        [Authorize]
        [HttpGet]
        public IActionResult CharacterCreation()
        {
            var allAtribute = _bgServices.GetAllAtribute();
            var bgModel = new CreateHeroViewModel();
            bgModel.Class = allAtribute
                .Class
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            bgModel.Race = allAtribute
                .Race
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            bgModel.Subrace = allAtribute
                .Subrace
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                })
                .ToList();
            bgModel.Origin = allAtribute
                .Origin
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            return View(bgModel);
        }
      

        [HttpPost]
        public IActionResult CharacterCreation(CreateHeroAnswerViewModel BgModel)
        {
            var user = _authService.GetCurrentUser().Id;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CharacterList", "BaldursGate");
            }
           var newHero = new NewBGBml()
            {
                Bone = BgModel.Bone,
                Name = BgModel.Name,
                ClassId = BgModel.ClassId,
                RaceId = BgModel.RaceId,
                SubraceId = BgModel.SubraceId,
                OriginId = BgModel.OriginId,
                CreatorId = user,
            };
            _bgServices.CreateNewHero(newHero);

            return RedirectToAction("CharacterList", "BaldursGate");
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
                    //Creator_Name = x.CreatorId.Name,
                })
                .ToList());
        }
        public IActionResult Remove(int id)
        {
            _bgServices.Remove(id);
            return RedirectToAction("CharacterList", "BaldursGate");
        }

    }
}
