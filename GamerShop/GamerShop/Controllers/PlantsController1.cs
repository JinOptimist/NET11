using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    public class PlantsController : Controller
    {
        public static List<Plants> PlantsList = new List<Plants>();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(AddPlansViewModel addPlansView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(addPlansView);
                }
                PlantsList.Add(new Plants(addPlansView.Name));
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var plantRoRemove = PlantsList.Find(x => x.Id == id);
            if (plantRoRemove != null)
            {
                PlantsList.Remove(plantRoRemove);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
