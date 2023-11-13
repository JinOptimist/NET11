using BusinessLayer.FootballService;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using GamerShop.Models.Football;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FootballLeaguesController : Controller
    {
        private IFootballLeagueServices _footballLeagueServices;
        public FootballLeaguesController(IFootballLeagueServices footballServices)
        {
            _footballLeagueServices = footballServices;
        }
        public int Count()
        => _footballLeagueServices.Count().Result;

        public IEnumerable<ShortFootballLeagueViewModel> Get(int skip, int count)
        => _footballLeagueServices
            .Get(skip, count).Result
            .Select(x => new ShortFootballLeagueViewModel 
            {
              Id = x.Id ,
              ShortName = x.ShortName 
            })
            .ToList();
        
    }
}
