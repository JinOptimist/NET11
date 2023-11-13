using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Services;
using GamerShop.Models.Football;
using Microsoft.AspNetCore.Mvc;
using GamerShop.Controllers.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace GamerShop.Controllers.Football
{
    [ViewLayout("_FootballLayout")]
    public class FootballLeaguesController : Controller
    {
        private IFootballLeagueServices _footballLeagueServices;
        private IAuthService _authService;
        
        public FootballLeaguesController(IFootballLeagueServices footballLeagueServices, IAuthService authService)
        {
            _footballLeagueServices = footballLeagueServices;
            _authService = authService;
        }
        [Authorize]
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
                Creator = user,
            });

            return View();
        }
        public IActionResult LeagueList()
        {
            return View(_footballLeagueServices
                        .GetAll().Result
                        .Select(x => new FootballLeagueViewModel
                        {
                            Id = x.Id,
                            FullName = x.FullName,
                            ShortName = x.ShortName,
                            Counrty = x.Country                            
                        }).
                        ToList());

        }
        public IActionResult Remove(int id)
        {
            _footballLeagueServices.Delete(id);
            return RedirectToAction("LeagueList", "FootballLeagues");
        }

        public IActionResult index()
        {
            return View();
        }

    }
}

