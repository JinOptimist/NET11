using System.ComponentModel;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers;

public class PcBuildController : Controller
{
    private IPcComponentsRepository _pcComponentsRepository;

    public PcBuildController(IPcComponentsRepository pcComponentsRepository)
    {
        _pcComponentsRepository = pcComponentsRepository;
    }

    public IActionResult Index()
    {
        var viewModel = _pcComponentsRepository
            .GetAll()
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

        var dbComponent = new PcComponent()
        {
            Title = pcComponentViewModel.Title,
            Category = pcComponentViewModel.Category,
            Price = pcComponentViewModel.Price
        };
        _pcComponentsRepository.Save(dbComponent);
        return RedirectToAction("Index", "PcBuild");
    }
    
    public IActionResult Remove(int id)
    {
        _pcComponentsRepository.Remove(id);
        return RedirectToAction("Index", "PcBuild");
    }
}