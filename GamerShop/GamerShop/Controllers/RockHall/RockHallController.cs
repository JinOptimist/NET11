using Microsoft.AspNetCore.Mvc;
using GamerShop.Models.RockHall;
using BusinessLayerInterfaces.RockHallServices;
using Microsoft.AspNetCore.Authorization;
using GamerShop.Services;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using Microsoft.AspNetCore.Diagnostics;
using GamerShop.Models.Users;

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

        [Authorize]
        public IActionResult Menu()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index(int page = 1, int perPage = 5)
        {
            var dataFromBl = _rockMemberServices.GetPaginatorBlm(page, perPage);
            var addtionalPageNumber = dataFromBl.Count % dataFromBl.PerPage == 0
                ? 0
                : 1;

            var availablePages = Enumerable
                .Range(1, dataFromBl.Count / dataFromBl.PerPage + addtionalPageNumber)
                .ToList();

            var viewModel = new PaginatorRockMemberViewModel
            {
                Page = dataFromBl.Page,
                Count = dataFromBl.Count,
                PerPage = dataFromBl.PerPage,
                AvailablePages = availablePages,
                RockMembers = dataFromBl.RockMembers.Select(userBlm => new InfoMemberViewModel
                {
                    Id = userBlm.Id,
                    FullName = userBlm.FullName,
                    Genre = userBlm.Genre,
                    EntryYear = userBlm.EntryYear,
                    YearOfBirth = userBlm.YearOfBirth,
                    CreatorName = userBlm.CreatorName,
                    CurrentBand = userBlm.CurrentBand
                })
                .ToList()
            };
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
