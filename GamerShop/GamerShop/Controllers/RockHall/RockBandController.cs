using BusinessLayerInterfaces.BusinessModels.RockHall.RockBand;
using BusinessLayerInterfaces.RockHallServices;
using DALInterfaces.Models;
using GamerShop.Models.Movies;
using GamerShop.Models.RockHall;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Controllers.RockHall
{
    public class RockBandController : Controller
    {
        private IRockBandServices _rockBandServices;
        private IAuthService _authService;
        private IRockMemberServices _rockMemberServices;

        public RockBandController(IRockBandServices rockBandServices,
                                  IAuthService authService,
                                  IRockMemberServices rockMemberServices)
        {
            _rockBandServices = rockBandServices;
            _authService = authService;
            _rockMemberServices = rockMemberServices;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Show()
        {
            var viewModel = _rockBandServices
                .GetAll()
                .Select(blmBand => new InfoBandViewModel
                {
                    Id = blmBand.Id,
                    FullName = blmBand.FullName,
                    CreatorName = blmBand.CreatorName
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _rockBandServices.Remove(id);
            return RedirectToAction("Show");
        }

        [HttpGet]
        [Authorize]
        public IActionResult NewRockBand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewRockBand(NewBandViewModel rockBandViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(rockBandViewModel);
            }

            var rockBandBlm = new RockBandPostBlm()
            {
                FullName = rockBandViewModel.FullName,
                CreatorId = _authService.GetCurrentUser().Id
            };

            _rockBandServices.Save(rockBandBlm);
            return RedirectToAction("Show");
        }

        [Authorize]
        [HttpGet]
        public IActionResult BandChooseMember()
        {
            var viewModel = new ChooseBandGetViewModel();

            var bands = _rockBandServices.GetAll();
            viewModel.AllBandsSelectListItem = bands
            .Select(bands => new SelectListItem()
            {
                Text = bands.FullName,
                Value = bands.Id.ToString(),
            })
            .ToList();

            var members = _rockMemberServices.GetAll();
            viewModel.AllMembersSelectListItem = members
                .Select(members => new SelectListItem()
                {
                    Text = members.FullName,
                    Value = members.Id.ToString(),
                }).ToList();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult BandChooseMember(ChooseBandPostViewModel viewModel)
        {
            _rockBandServices.ChooseMember(viewModel.BandId, viewModel.MemberId);
            return RedirectToAction("Index", "RockHall");
        }
    }
}
