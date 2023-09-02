using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Models.Football;
using GamerShop.Services;
using GamerShop.Services.Football;
using Microsoft.AspNetCore.Mvc;


namespace GamerShop.Controllers.Football
{
    public class FootballClubsController : Controller
    {
        private IFootballServices<FootballClubBlm> _foootballClubsServices;
        private IAuthService _authService;



        public FootballClubsController(IFootballServices<FootballClubBlm> foootballClubsService, IAuthService authService)
        {
            _foootballClubsServices = foootballClubsService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult NewClub()
        {

            return View();
        }

        [HttpPost]
        public IActionResult NewClub(FootballClubViewModel footballClub)
        {
            var user = _authService.GetCurrentUser();

            _foootballClubsServices.Save(new FootballClubBlm
            {
                Name = footballClub.Name,
                Stadium = footballClub.Stadium,
                Creator = user,
                ShortFootballLeagueInfo = new ShortFootballLeagueBLM 
                {
                Id = footballClub.FootballLeagueinfo.id,
                ShortName = footballClub.FootballLeagueinfo.ShortName
                },
            }); 

            return View();
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
                            CreatorName = x.Creator.Name,
                            FootballLeagueinfo = new ShortFootballLeagueViewModel
                            {
                             id = x.ShortFootballLeagueInfo.Id,
                             ShortName = x.ShortFootballLeagueInfo.ShortName
                            },
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
