using DALInterfaces.Models;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GamerShop.Controllers
{
    public class BaldursGateController : Controller

    {
        private IPersRepository _persRepository;

        public BaldursGateController(IPersRepository persRepository)
        {
            _persRepository = persRepository;
        }



        [HttpGet]
        public IActionResult CharacterCreation()
        {
            return View();
        }
        public IActionResult CharacterList()
        {
            //Я овощ
            return View(_persRepository.GetAll().
                                        Select(x => new BaldursGateModel
                                        {
                                          Id = x.Id,
                                          Name = x.Name,
                                          Class = x.Class,
                                         }).
                                         ToList());
        }

        [HttpPost]
        public IActionResult CharacterCreation(BaldursGateModel BgModel)

        {
            _persRepository.Save(new Pers
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
            _persRepository.Remove(id);
            return RedirectToAction("CharacterList", "BaldursGate");
        }

    }
}
