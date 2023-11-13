using GamerShop.Models.BaldursGate;
using Microsoft.AspNetCore.Mvc;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.BG;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace GamerShop.Controllers.BaldursGate
{
    [Authorize]
    public class BaldursGateController : Controller

    {
        private IBgServices _bgServices;
        private IWebHostEnvironment _webHostEnvironment;
        private IAuthService _authService;
        private IBGServiceGeneratorPDF _bgServiceGeneratorPDF;

        private static Dictionary<int,IBGServiceGeneratorPDF> PDFJobs = new Dictionary<int,IBGServiceGeneratorPDF>();
        public BaldursGateController(IBgServices bgServices, IAuthService authService, IWebHostEnvironment environment, IBGServiceGeneratorPDF bgServiceGenerator)
        {
            _webHostEnvironment = environment;
            _bgServices = bgServices;
            _authService =  authService;
            _bgServiceGeneratorPDF = bgServiceGenerator;
        }

       
        [HttpGet]
        public IActionResult CharacterCreation()
        {
            var allAtribute = _bgServices.GetAllAtribute();
            var bgModel = new CreateHeroViewModel();
            bgModel.Class = allAtribute
                .Class
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            bgModel.Race = allAtribute
                .Race
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            bgModel.Subrace = allAtribute
                .Subrace
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                })
                .ToList();
            bgModel.Origin = allAtribute
                .Origin
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            return View(bgModel);
        }
      

        [HttpPost]
        public IActionResult CharacterCreation(CreateHeroAnswerViewModel BgModel)
        {
            var user = _authService.GetCurrentUser().Id;
            //var fileName = $"{user}.jpg";
            //var path = Path.Combine(_webHostEnvironment.WebRootPath,"img","BG",fileName);
            //var a = BgModel.Avatar;
            //using (var fs = new FileStream(path, FileMode.CreateNew))
            //{
            //    BgModel.Avatar.CopyTo(fs);
            //}
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CharacterList", "BaldursGate");
            }
           var newHero = new NewBGBml()
            {
                Bone = BgModel.Bone,
                Name = BgModel.Name,
                ClassId = BgModel.ClassId,
                RaceId = BgModel.RaceId,
                SubraceId = BgModel.SubraceId,
                OriginId = BgModel.OriginId,
                CreatorId = user,
            };
            
            _bgServices.CreateNewHero(newHero);

            return RedirectToAction("CharacterList", "BaldursGate");
        }
        public IActionResult CharacterList(int page =1, int perPage = 10)
        {
            //Я овощ
            var data = _bgServices.GetCharacterListBml(page, perPage);
            var addPageNum = data.Count % data.PerPage == 0 ? 0 : 1;
            var availablePages = Enumerable
                .Range(1, data.Count / data.PerPage + addPageNum)
                .ToList();
            var BgModel = new PaginatorHeroViewModel
            {
                Page = data.Page,
                PerPage = data.PerPage,
                AvailablePages = availablePages,
                Count = data.Count,
                HeroList = data.HeroList
                    .Select(m => new HeroListViewModel
                    {   Id = m.Id,
                        Name = m.Name,
                        Class = m.Class,
                        Subrace = m.Subrace,
                        Bone = m.Bone,
                        Оrigin = m.Оrigin,
                        CreatorId = m.CreatorId,
                        Races = m.Races,

                    }).ToList()
            };
            return View(BgModel);
        }

        public IActionResult Remove(int id)
        {
            _bgServices.Remove(id);
            return RedirectToAction("CharacterList", "BaldursGate");
        }
       

        public IActionResult Report()
        {
            return View();

        }

        public IActionResult ReportCreate()
        {
            var userId = _authService.GetCurrentUser().Id;
            var fileName = $"{userId}.pdf";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "BGReports",
                fileName);
            var heroName = _bgServices.GetHeroList();
            var counthero = heroName.Count;
            var t = new Task(() => _bgServiceGeneratorPDF.Report(path, heroName));
            PDFJobs.Add(counthero, _bgServiceGeneratorPDF);
            t.Start();
            return RedirectToAction("Reportdecimal", "BaldursGate");
        }

        public IActionResult Reportdecimal()
        {
            var viewmodel = new ReportViewModel();
            var heroCount = _bgServices.GetHeroList().Count;
            if (!PDFJobs.ContainsKey(heroCount))
            {
                return View(viewmodel);
            }
            var pdfgen = PDFJobs[heroCount];
            decimal dec1 = pdfgen.AllheroCount;
            decimal dec2 = pdfgen.heroCount;
            viewmodel.pdfJobs = Math.Round(dec2 / dec1, 2) * 100;
            viewmodel.IsFileReady = pdfgen.IsReady;

            return View(viewmodel);
        }

        public IActionResult Dowloadreport()
        {
            var heroCount = _bgServices.GetHeroList().Count;
            var path = PDFJobs[heroCount].ResultPath;
            var fileStream = new FileStream(path, FileMode.Open);
            return File(fileStream, "application/pdf");
        }
    }
}
