using DALInterfaces.Repositories;
using GamerShop.Models;
using DALInterfaces.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.RockHallController
{
    public class RockHallController : Controller
    {
        /*public static List<RockMembers> _rockPerson = new List<RockMembers>()
        {
            new RockMembers("The Beatles", "Psychedelic Rock", 1994, 1956),
            new RockMembers("Queen", "Pop Rock", 1999, 1958),
            new RockMembers("John Bon Jovi", "Rock-N-Roll", 2001, 1973),
            new RockMembers("The Who", "Psychedelic Rock", 1988, 1963),
            new RockMembers("System Of Down", "Rock-N-Roll", 2003, 1993),
            new RockMembers("The Offspring", "Punk Rock", 2011, 1993),
            new RockMembers("System of a Down", "Hard Rock", 2001, 1973)
        };*/

        private IRockMemberRepository _rockMemberRepository;

        public RockHallController(IRockMemberRepository rockMemberRepository)
        {
            _rockMemberRepository = rockMemberRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = _rockMemberRepository.GetAll();                                  
            return View(viewModel);
        }

        public IActionResult Delete(int index)
        {
            //_rockPerson.RemoveAt(index);
            _rockMemberRepository.Delete(index);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewRockMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRockMember(RockFameViewModel rockFameViewModel)
        {
            _rockMemberRepository.Save(new RockMembers(rockFameViewModel.FullName,
                                                       rockFameViewModel.Genre,
                                                       rockFameViewModel.EntryYear,
                                                       rockFameViewModel.YearOfBirth));
           // _rockPerson.Add(new RockMembers(rockFameViewModel.FullName, rockFameViewModel.Genre, rockFameViewModel.EntryYear, rockFameViewModel.YearOfBirth));
            return RedirectToAction("Index");
        }
    }
}
