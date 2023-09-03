using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Models.Football;
using GamerShop.Services;
using GamerShop.Services.Football;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GamerShop.Controllers.Football
{
    
    public class FootballClubsController : Controller
    {
        private IFootballServices<FootballClubBlm> _foootballClubsServices;
        private IAuthService _authService;
        private IPaginatorService _paginatorService;


        public FootballClubsController(IFootballServices<FootballClubBlm> foootballClubsService, IAuthService authService, IPaginatorService paginatorService)
        {
            _foootballClubsServices = foootballClubsService;
            _authService = authService;
            _paginatorService = paginatorService;
        }
        [Authorize]
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
        public IActionResult ClubsList(int page = 1, int perPage = 10)
        {

            var viewModel = _paginatorService
                           .GetPaginatorViewModel(_foootballClubsServices, MapToFootClubViewModel, page, perPage);

            return View(viewModel);

        }
        public IActionResult Remove(int id)
        {
            _foootballClubsServices.Delete(id);
            return RedirectToAction("ClubsList", "FootballClubs");
        }

        private FootballClubViewModel MapToFootClubViewModel(FootballClubBlm footballClubBlm)
        => new FootballClubViewModel
        {
            CreatorName = footballClubBlm.Creator.Name,
            Id = footballClubBlm.Id,
            Stadium = footballClubBlm.Stadium,
            Name = footballClubBlm.Name,
            FootballLeagueinfo = new ShortFootballLeagueViewModel
            {
                id = footballClubBlm.ShortFootballLeagueInfo.Id,
                ShortName = footballClubBlm.ShortFootballLeagueInfo.ShortName
            },

        };
    }

}
