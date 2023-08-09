using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GamerShop.Controllers
{
    public class BaldursGateController : Controller

    {
        public static List<string> _BGclass = new List<string>();

        [HttpGet]
        public IActionResult CharacterCreation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CharacterCreation(BaldursGateModel BgModel)

        {

            if (BgModel.Bone > 15)
            {
                _BGclass.Add(BgModel.Name);

            }

            return View();
        }
        public IActionResult Delete(string id)

        {
            if (!string.IsNullOrEmpty(id))
            {
                _BGclass.Remove(_BGclass[Convert.ToInt32(id)]);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
