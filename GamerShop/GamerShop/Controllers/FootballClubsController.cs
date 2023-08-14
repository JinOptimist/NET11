﻿using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;


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
                _foootballClubsRepository.Save(new FootballClub
                {
                    Name = footballClub.Name,
                    Stadium = footballClub.Stadium,
                }) ;
   
            return View();
        }
        public IActionResult ClubsList()
        {
            return View(_foootballClubsRepository.GetAll().
                                                  Select(x=>new FootballClubViewModel
                                                  { 
                                                  Id = x.Id,
                                                  Name = x.Name,
                                                  Stadium = x.Stadium,
                                                  }).
                                                  ToList());
        }
        public IActionResult Remove(int id)
        {
           _foootballClubsRepository.Remove(id);
           return RedirectToAction("ClubsList", "FootballClubs");
        }

    }

}