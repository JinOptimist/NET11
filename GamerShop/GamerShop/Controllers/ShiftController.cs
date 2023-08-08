using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class ShiftController : Controller
{
    public static List<ShiftViewModel> Shifts = new List<ShiftViewModel>();
    
    public IActionResult Index()
    {
        return View(Shifts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(ShiftViewModel shiftViewModel)
    {
        if (Shifts.Count != 0)
        {
            shiftViewModel.Id = Shifts.Last().Id + 1;
        }
        else
        {
            shiftViewModel.Id = 0;
        }
        Shifts.Add(shiftViewModel);
        return View();
    }
    
    public IActionResult Delete(int id)
    {
        var shiftToDelete = Shifts.FirstOrDefault(shift => shift.Id == id);
        if (shiftToDelete != null)
        {
            Shifts.Remove(shiftToDelete);
        }
        return RedirectToAction("Index", "Shift");
    }
    
}