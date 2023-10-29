using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.RockHallServices;
using GamerShop.Controllers.Attributes;
using GamerShop.Controllers.RockHall;
using GamerShop.Models.RockHall;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.RockHallController
{
    [ViewLayout("_RockHallLayout")]
    public class RockHallController : Controller
    {
        private IRockMemberServices _rockMemberServices;
        private IAuthService _authService;
        private IPaginatorService _paginatorService;
        private IWebHostEnvironment _webHostEnvironment;

        public RockHallController(IRockMemberServices rockMemberServices, IAuthService authService, IPaginatorService paginatorService, IWebHostEnvironment webHostEnvironment)
        {
            _rockMemberServices = rockMemberServices;
            _authService = authService;
            _paginatorService = paginatorService;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpGet]
        public IActionResult RockSettings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RockSettings(RockSettingsViewModel rockSettingsViewModel)
        {
            var fileName = "background.jpg";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "img",
                "RockHall",
                fileName);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                rockSettingsViewModel.Background.CopyTo(fs);
            }
            return View();
        }
    }
}
