using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Models.Football;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Football
{
    public class FootballLeaguesController : Controller
    {
        IFootballServices<FootballLeagueBlm> _footballServices;

        public FootballLeaguesController (IFootballServices<FootballLeagueBlm> footballServices)
        {
            _footballServices = footballServices;
        }

        [HttpGet]
        public IActionResult AddLegue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLegue(FootballLeagueViewModel footballLegue)
        {
            _footballServices.Save(new FootballLeagueBlm
            {
                Country = footballLegue.County,
                FullName = footballLegue.FullName,
                ShortName = footballLegue.ShortName,
            });

            return View();
        }
    }
}
