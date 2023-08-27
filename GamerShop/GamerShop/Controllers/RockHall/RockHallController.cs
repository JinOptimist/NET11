using Microsoft.AspNetCore.Mvc;
using GamerShop.Models.RockHall;
using BusinessLayerInterfaces.RockHallServices;
using Microsoft.AspNetCore.Authorization;
using GamerShop.Services;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;

namespace GamerShop.Controllers.RockHallController
{
    public class RockHallController : Controller
    {
        private IRockMemberServices _rockMemberServices;
        private IAuthService _authService;

        public RockHallController(IRockMemberServices rockMemberServices, IAuthService authService)
        {
            _rockMemberServices = rockMemberServices;
            _authService = authService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var viewModel = _rockMemberServices
                .GetAll()
                .Select(blmMember => new InfoMemberViewModel
                {
                    Id = blmMember.Id,
                    FullName = blmMember.FullName,
                    Genre = blmMember.Genre,
                    YearOfBirth = blmMember.YearOfBirth,
                    EntryYear = blmMember.EntryYear,
                    CreatorName = blmMember.CreatorName,
                    CurrentBand = blmMember.CurrentBand,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _rockMemberServices.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
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

            var rockMemberBlm = new RockMemberPostBlm()
            {
                FullName = rockFameViewModel.FullName,
                Genre = rockFameViewModel.Genre,
                EntryYear = rockFameViewModel.EntryYear,
                YearOfBirth = rockFameViewModel.YearOfBirth,
                CreatorId = _authService.GetCurrentUser().Id
            };

            _rockMemberServices.Save(rockMemberBlm);
            return RedirectToAction("Index");
        }
    }
}
