using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Services;
using GamerShop.Models.Football;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Football
{
    public class FootballLeaguesConrtoller : Controller
    {
        private IFootballServices<FootballLeagueBLM> _footballLeagueServices;
        private IAuthService _authService;

        public FootballLeaguesConrtoller(IFootballServices<FootballLeagueBLM> footballLeagueServices, IAuthService authService)
        {
            _footballLeagueServices = footballLeagueServices;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult NewLeague()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewLeague(FootballLeagueViewModel footballLeague)
        {
            var user = _authService.GetCurrentUser();

            _footballLeagueServices.Save(new FootballLeagueBLM
            {
                FullName = footballLeague.FullName,
                ShortName = footballLeague.ShortName,
                Country = footballLeague.Counrty,
            });

            return View();
        }
        public IActionResult LeagueList()
        {
            return View(_footballLeagueServices
                        .GetAll()
                        .Select(x => new FootballLeagueBLM
                        {
                            Id = x.Id,
                            FullName = x.FullName,
                            ShortName = x.ShortName,
                            Country = x.Country
                        }).
                        ToList());

        }
        public IActionResult Remove(int id)
        {
            _footballLeagueServices.Delete(id);
            return RedirectToAction("LeagueList", "FootballLeagues");
        }

    }
}

