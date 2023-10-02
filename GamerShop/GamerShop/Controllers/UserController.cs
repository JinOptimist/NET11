using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using GamerShop.Controllers.AuthCustomAttribute;
using GamerShop.Models.Users;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IWebHostEnvironment _webHostEnvironment;
        private Services.IAuthService _authService;
        private IPdfGeneratorService _pdfGeneratorService;

        private IPaginatorService _paginatorService;

        private static Dictionary<int, IPdfGeneratorService> _currentPdfJobs = new Dictionary<int, IPdfGeneratorService>();

        public UserController(IUserService userService,
            IPaginatorService paginatorService,
            IWebHostEnvironment webHostEnvironment,
            Services.IAuthService authService,
            IPdfGeneratorService pdfGeneratorService)
        {
            _userService = userService;
            _paginatorService = paginatorService;
            _webHostEnvironment = webHostEnvironment;
            _authService = authService;
            _pdfGeneratorService = pdfGeneratorService;
        }


        public IActionResult Index(int page = 1, int perPage = 10)
        {
            var viewModel = _paginatorService
                .GetPaginatorViewModel(_userService, MapBlmToViewModel, page, perPage);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var viewModel = new ProfileViewModel();
            var currentUserId = _authService.GetCurrentUser().Id;
            if (!_currentPdfJobs.ContainsKey(currentUserId))
            {
                return View(viewModel);
            }

            var pdfGenerator = _currentPdfJobs[currentUserId];
            decimal perfomedUserCountDec = pdfGenerator.PerfomedUserCount;
            decimal allUserCountDec = pdfGenerator.AllUserCount;
            viewModel.CurrentJobProgress = Math.Round(perfomedUserCountDec / allUserCountDec, 2) * 100;
            viewModel.IsFileReady = pdfGenerator.IsReady;

            return View(viewModel);
        }

        public IActionResult DownloadReport()
        {
            var userId = _authService.GetCurrentUser().Id;
            var path = _currentPdfJobs[userId].ResultPath;
            var fileStream = new FileStream(path, FileMode.Open);
            return File(fileStream, "application/pdf");
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel profileViewModel)
        {
            var userId = _authService.GetCurrentUser().Id;
            var fileName = $"{userId}.jpg";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "img",
                "avatars",
                fileName);

            using (var fs = new FileStream(path, FileMode.Create))
            {
                profileViewModel.Avatar.CopyTo(fs);
            }

            return View();
        }

        private UserViewModel MapBlmToViewModel(UserBlm userBlm)
        {
            return new UserViewModel
            {
                Id = userBlm.Id,
                Name = userBlm.Name,
                FavMovieName = userBlm.FavoriteMovieName,
                AgeInDays = userBlm.AgeInDays,
            };
        }

        public IActionResult GeneratePdfWithUserNames()
        {
            var userId = _authService.GetCurrentUser().Id;
            var fileName = $"{userId}.pdf";
            var path = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "reports",
                fileName);

            var curentUserId = _authService.GetCurrentUser().Id;
            var userNames = _userService.GetAllUserNames();
            var task = new Task(() => _pdfGeneratorService.GeneratePdfWithUsers(path, userNames));
            _currentPdfJobs.Add(curentUserId, _pdfGeneratorService);
            task.Start();

            return Json("We start the work");
        }
    }
}
