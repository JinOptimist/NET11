using DALInterfaces.Repositories;
using DALInterfaces.Models;
using Microsoft.AspNetCore.Mvc;
using GamerShop.Models.RockHall;

namespace GamerShop.Controllers.RockHallController
{
    public class RockHallController : Controller
    {
        private IRockMemberRepository _rockMemberRepository;

        public RockHallController(IRockMemberRepository rockMemberRepository)
        {
            _rockMemberRepository = rockMemberRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = _rockMemberRepository
                .GetAll()
                .Select(dbMember => new InfoMemberViewModel
                {
                    Id = dbMember.Id,
                    FullName = dbMember.FullName,
                    Genre = dbMember.Genre,
                    YearOfBirth = dbMember.YearOfBirth,
                    EntryYear = dbMember.EntryYear,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _rockMemberRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewRockMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRockMember(NewMemberViewModel rockFameViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(rockFameViewModel);
            }

            var rockMemberDb = new RockMember()
            {
                FullName = rockFameViewModel.FullName,
                Genre = rockFameViewModel.Genre,
                EntryYear = rockFameViewModel.EntryYear,
                YearOfBirth = rockFameViewModel.YearOfBirth
            };

            _rockMemberRepository.Save(rockMemberDb);
            return RedirectToAction("Index");
        }
    }
}
