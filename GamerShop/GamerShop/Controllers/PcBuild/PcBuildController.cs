using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using BusinessLayerInterfaces.PcBuilderServices;
using GamerShop.Models;
using GamerShop.Models.PcBuild;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Controllers.PcBuild;

public class PcBuildController : Controller
{
    private IBuildServices _buildServices;

    public PcBuildController(IBuildServices buildServices)
    {
        _buildServices = buildServices;
    }

    public IActionResult Index()
    {
        var viewModel = _buildServices
            .GetAllBuildsInShortType()
            .Select(build => new BuildsIndexViewModel()
            {
                UserName = build.UserName,
                UserPhotoPath = build.MainPhotoPath,
                Price = build.Price,
                Rating = build.Rating,
                BuildName = build.Label,
                BuildPhotoPath = build.MainPhotoPath,
                Processor = build.ProcessorName,
                GPU = build.GPUsNames
            });
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult CreateBuild()
    {
        var allComponents = _buildServices.GetAllComponents();
        var viewModel = new CrealeBuildShowViewModel()
        {
            Cases = allComponents.Cases,
            Processors = allComponents.Processors,
            Coolers = allComponents.Coolers,
            Gpus = allComponents.Gpus,
            Hdds = allComponents.Hdds,
            Motherboards = allComponents.Motherboards,
            Rams = allComponents.Rams,
            Ssds = allComponents.Ssds,
            Psus = allComponents.Psus
        };
        ViewBag.Cases = new SelectList(allComponents.Cases, "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateBuild(CreateBuildViewModel viewModel)
    {
        var cases = viewModel.Korpus;
        return View();
    }

    public IActionResult Remove(int id)
    {
        return RedirectToAction("Index", "PcBuild");
    }
}