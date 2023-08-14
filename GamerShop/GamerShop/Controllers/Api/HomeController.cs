using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private IHomeServices _homeServices;

		public HomeController(IHomeServices homeServices)
		{
			_homeServices = homeServices;
		}

		public List<IndexViewModel> GetIndexViewModel()
		{
			var viewModels = _homeServices
			   .GetLastLoginUsers()
			   .Select(dbUser => new IndexViewModel
			   {
				   Id = dbUser.Id,
				   Name = dbUser.Name,
			   })
			   .ToList();

			return viewModels;
		}
	}
}
