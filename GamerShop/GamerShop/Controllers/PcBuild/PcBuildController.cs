using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using BusinessLayerInterfaces.PcBuilderServices;
using GamerShop.Services;
using GamerShop.Models.PcBuild;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Controllers.PcBuild;

public class PcBuildController : Controller
{
    private readonly IBuildServices _buildServices;
    private readonly IAuthService _authService;

    public PcBuildController(IBuildServices buildServices, IAuthService authService)
    {
        _buildServices = buildServices;
        _authService = authService;
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

    [Authorize]
    [HttpGet]
    public IActionResult CreateBuild()
    {
        var allComponents = _buildServices.GetAllComponents();
        var viewModel = new CreateBuildViewModel();
        viewModel.Cases = allComponents
            .Cases
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Processors = allComponents
            .Processors
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Motherboards = allComponents
            .Motherboards
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Ssds = allComponents
            .Ssds
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Gpus = allComponents
            .Gpus
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Hdds = allComponents
            .Hdds
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Coolers = allComponents
            .Coolers
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Rams = allComponents
            .Rams
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        viewModel.Psus = allComponents
            .Psus
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            })
            .ToList();
        return View(viewModel);
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult CreateBuild(CreateBuildAnswerViewModel viewModel)
    {
        var currentUserId = _authService.GetCurrentUser().Id;
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", "PcBuild");
        }

        var newBuild = new NewBuildBlm()
        {
            CreatorId = currentUserId,
            ProcessorId = viewModel.ProcessorId,
            MotherboardId = viewModel.MotherboardId,
            GpuId = viewModel.GpuId,
            GpuCount = viewModel.GpuCount,
            CurrentCaseId = viewModel.CaseId,
            CoolerId = viewModel.CoolerId,
            HddId = viewModel.HddId,
            HddCount = viewModel.HddCount,
            SsdId = viewModel.SsdId,
            SsdCount = viewModel.SsdCount,
            RamId = viewModel.RamId,
            RamCount = viewModel.RamCount,
            PsuId = viewModel.PsuId,
            Title = viewModel.Title,
            Description = viewModel.Description
        };
        _buildServices.CreateNewBuild(newBuild);
        return RedirectToAction("Index", "PcBuild");
    }

    public IActionResult Remove(int id) //TODO
    {
        return RedirectToAction("Index", "PcBuild");
    }
}