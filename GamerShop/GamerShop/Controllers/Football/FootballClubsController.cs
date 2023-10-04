using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Controllers.Attributes;
using GamerShop.Models.Football;
using GamerShop.Models.RockHall;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GamerShop.Controllers.Football
{
    [ViewLayout("_FootballLayout")]
    public class FootballClubsController : Controller
    {
        private IFootballClubService _foootballClubsServices;
        private IAuthService _authService;
        private IPaginatorService _paginatorService;
        private IFootballLeagueServices _footballLeagueBLMServices;
        private IFilterService _filterService;

        public FootballClubsController(IFootballClubService foootballClubsService, IAuthService authService, IPaginatorService paginatorService, IFootballLeagueServices footballLeagueBLMServices,
                                                                                                                                                                                IFilterService filterService)
        {
            _foootballClubsServices = foootballClubsService;
            _authService = authService;
            _paginatorService = paginatorService;
            _footballLeagueBLMServices = footballLeagueBLMServices;
            _filterService = filterService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult NewClub()
        {

            return View(GetViewModelForNewClub());
        }

        [HttpPost]
        public IActionResult NewClub(FootballClubViewModel<List<ShortFootballLeagueViewModel>> footballClub)
        {
            var user = _authService.GetCurrentUser();
            _foootballClubsServices.Save(new FootballClubBlm
            {
                Name = footballClub.Name,
                Stadium = footballClub.Stadium,
                Creator = user,
                ShortFootballLeagueInfo = new ShortFootballLeagueBLM
                {
                    Id = footballClub.SelectedLigue
                   .First()
                }
            });

            return View(GetViewModelForNewClub());
        }
        public IActionResult ClubsList(int page = 1, int perPage = 10, List<object> filters = null)
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

        private FootballClubViewModel<ShortFootballLeagueViewModel> MapToFootClubViewModel(FootballClubBlm footballClubBlm)
        => new FootballClubViewModel<ShortFootballLeagueViewModel>
        {
            CreatorName = footballClubBlm.Creator.Name,
            Id = footballClubBlm.Id,
            Stadium = footballClubBlm.Stadium,
            Name = footballClubBlm.Name,
            FootballLeagueinfo = new ShortFootballLeagueViewModel
            {
                Id = footballClubBlm.ShortFootballLeagueInfo.Id,
                ShortName = footballClubBlm.ShortFootballLeagueInfo.ShortName
            },

        };
        private FootballClubViewModel<List<ShortFootballLeagueViewModel>> GetViewModelForNewClub()
        => new FootballClubViewModel<List<ShortFootballLeagueViewModel>>
        {
            FootballLeagueinfo = _footballLeagueBLMServices.GetLimitedAmountLigues(1) // to fill in the list by clicking 
            .Select(x => new ShortFootballLeagueViewModel
            {
                Id = x.Id,
                ShortName = x.ShortName
            }).ToList(),

        };
    }

}
