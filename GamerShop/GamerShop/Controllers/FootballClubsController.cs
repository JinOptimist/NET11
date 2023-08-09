using DALInterfaces.Models;
using DALInterfaces.Repositories;
using DALWrongDB.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace GamerShop.Controllers
{
    public class FootballClubsController : Controller
    {
        private IFootballClubRepository _foootballClubsRepository; 
        

        public FootballClubsController(IFootballClubRepository foootballClubsRepository)
        {
            _foootballClubsRepository = foootballClubsRepository;
        }

        [HttpGet]
        public IActionResult NewClub()
        {
           return View();
        }

        [HttpPost]
        public IActionResult NewClub(FootballClubViewModel footballClub)
        {
            if (footballClub != null) 
            {

                _foootballClubsRepository.Save(new FootballClub
                {
                    Name = footballClub.Name,
                    Stadium = footballClub.Stadium,
                }) ;
            }
            return View();
        }
        public IActionResult ClubsList()
        {
            return View(_foootballClubsRepository.GetAll().
                                                  Select(x=>x.Name).
                                                  ToList());
        }
        public IActionResult Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _foootballClubsRepository.Remove(id);
            }
           return RedirectToAction("ClubsList", "FootballClubs");
        }

    }

}
