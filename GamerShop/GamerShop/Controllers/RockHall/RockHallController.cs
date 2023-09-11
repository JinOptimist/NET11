using Microsoft.AspNetCore.Mvc;
using GamerShop.Models.RockHall;
using BusinessLayerInterfaces.RockHallServices;
using Microsoft.AspNetCore.Authorization;
using GamerShop.Services;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using Microsoft.AspNetCore.Diagnostics;
using GamerShop.Models.Users;
using BusinessLayerInterfaces.BusinessModels;
using GamerShop.Controllers.RockHall;

namespace GamerShop.Controllers.RockHallController
{
    public class RockHallController : Controller
    {
        private IRockMemberServices _rockMemberServices;
        private IAuthService _authService;
        private IPaginatorService _paginatorService;

        public RockHallController(IRockMemberServices rockMemberServices, IAuthService authService, IPaginatorService paginatorService)
        {
            _rockMemberServices = rockMemberServices;
            _authService = authService;
            _paginatorService = paginatorService;
        }

        [Authorize]
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult IsNotAdmin()
        {
            return View();
        }

        [Authorize]
        [AdminOnly]
        public IActionResult Index(int page = 1, int perPage = 5)
        {

            var viewModel = _paginatorService
                .GetPaginatorViewModel(_rockMemberServices,
                                       MapRockMemberGetBlmToInfoMemberViewModel,
                                       page,
                                       perPage);
            return View(viewModel);
        }

        private InfoMemberViewModel MapRockMemberGetBlmToInfoMemberViewModel(RockMemberGetBlm rockMember)
        {
            return new InfoMemberViewModel
            {
                Id = rockMember.Id,
                FullName = rockMember.FullName,
                EntryYear = rockMember.EntryYear,
                YearOfBirth = rockMember.YearOfBirth,
                Genre = rockMember.Genre,
                CreatorName = rockMember.CreatorName,
                CurrentBandName = rockMember.CurrentBandName,
            };
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
