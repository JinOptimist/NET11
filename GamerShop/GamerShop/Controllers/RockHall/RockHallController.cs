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
                .Select(dbUser => new InfoMemberViewModel
                {
                    Id = dbUser.Id,
                    FullName = dbUser.FullName,
                    Genre = dbUser.Genre,
                    YearOfBirth = dbUser.YearOfBirth,
                    EntryYear = dbUser.EntryYear,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _rockMemberRepository.Delete(id);
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
