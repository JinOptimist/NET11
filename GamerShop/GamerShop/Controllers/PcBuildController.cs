using System.ComponentModel;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class PcBuildController : Controller
{
    private IPcComponentServices _pcComponentServices;

    public PcBuildController(IPcComponentServices pcComponentServices)
    {
        _pcComponentServices = pcComponentServices;
    }

    public IActionResult Index()
    {
        var viewModel = _pcComponentServices
            .GetAllPcComponents()
            .Select(component => new PcComponentViewModel()
            {
                Id = component.Id,
                Category = component.Category,
                Price = component.Price,
                Title = component.Title
            })
            .ToList();
        return View(viewModel);
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(PcComponentViewModel pcComponentViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var dbComponent = new PcComponentBlm()
        {
            Title = pcComponentViewModel.Title,
            Category = pcComponentViewModel.Category,
            Price = pcComponentViewModel.Price
        };
        _pcComponentServices.Save(dbComponent);
        return RedirectToAction("Index", "PcBuild");
    }
    
    public IActionResult Remove(int id)
    {
        _pcComponentServices.Remove(id);
        return RedirectToAction("Index", "PcBuild");
    }
}