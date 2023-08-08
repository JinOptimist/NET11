using GamerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace GamerShop.Controllers
{
    public class FootballClubsController : Controller
    {
        public static List<string> _names = new List<string>();
        
        [HttpGet]
        public IActionResult NewClub()
        {
           return View();
        }

        [HttpPost]
        public IActionResult NewClub(FootballClub footballClub)
        {
            if (footballClub != null) 
            {
             _names.Add(footballClub.Name);
            }
            return View();
        }
        public IActionResult ClubsList()
        {
            return View(_names);
        }
        public IActionResult Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _names.Remove(_names[Convert.ToInt32(id)]);
            }
           return RedirectToAction("ClubsList", "FootballClubs");
        }

    }

}
