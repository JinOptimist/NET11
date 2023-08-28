using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Models.Football;
using GamerShop.Services;
using Microsoft.AspNetCore.Mvc;


namespace GamerShop.Controllers.Football
{
    public class FootballClubsController : Controller
    {
        private IFootballServices<FootballClubsBlm> _foootballClubsServices;
        private IAuthService _authService;

        public FootballClubsController(IFootballServices<FootballClubsBlm> foootballClubsService, IAuthService authService)
        {
            _foootballClubsServices = foootballClubsService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult NewClub()
        {
            return View("~/Views/Football/NewClub.cshtml");
        }

        [HttpPost]
        public IActionResult NewClub(FootballClubViewModel footballClub)
        {
            var user = _authService.GetCurrentUser();

            _foootballClubsServices.Save(new FootballClubsBlm
            {
                Name = footballClub.Name,
                Stadium = footballClub.Stadium,
                Creator = user
            });

            return View("~/Views/Football/NewClub.cshtml");
        }
        public IActionResult ClubsList()
        {
            return View(_foootballClubsServices
                        .GetAll()
                        .Select(x => new FootballClubViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Stadium = x.Stadium,
                            CreatorName = x.Creator.Name
                        }).
                        ToList());

        }
        public IActionResult Remove(int id)
        {
            _foootballClubsServices.Delete(id);
            return RedirectToAction("ClubsList", "FootballClubs");
        }
       
    }

}
