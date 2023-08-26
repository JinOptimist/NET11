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

    public IActionResult Index(int page = 1, int perPage = 10)
    {
        var dataFromBl = _buildServices.GetIndexBuildBlm(page, perPage);
        var addtionalPageNumber = dataFromBl.Count % dataFromBl.PerPage == 0 
            ? 0 
            : 1;
        
        var availablePages = Enumerable
            .Range(1, dataFromBl.Count / dataFromBl.PerPage + addtionalPageNumber)
            .ToList();

        var viewModel = new PaginatorBuildsViewModel
        {
            Page = dataFromBl.Page,
            PerPage = dataFromBl.PerPage,
            Count = dataFromBl.Count,
            AvailablePages = availablePages,
            Builds = dataFromBl
                .Builds
                .Select(shortBuildBlm => new BuildsIndexViewModel
                {
                    UserName = shortBuildBlm.CreatorName,
                    Price = shortBuildBlm.Price,
                    Rating = shortBuildBlm.Rating.ToString(),
                    BuildName = shortBuildBlm.Label,
                    BuildPhotoPath = shortBuildBlm.PhotoPath,
                    Processor = shortBuildBlm.ProcessorName,
                    GPU = shortBuildBlm.GpuName ?? ""
                })
                .ToList()
        };
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