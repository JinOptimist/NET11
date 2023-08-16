using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamerShop.Controllers
{
    public class FootballClubsController : Controller
    {
        private IFootballServices _foootballClubsServices;

        public FootballClubsController(IFootballServices _foootballClubsServices)
        {
            _foootballClubsServices = _foootballClubsServices;
        }

        [HttpGet]
        public IActionResult NewClub()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewClub(FootballClubViewModel footballClub)
        {
            _foootballClubsServices.Save(new FootballClubsBlm
            {
                Name = footballClub.Name,
                Stadium = footballClub.Stadium,
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
