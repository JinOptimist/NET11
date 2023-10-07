using BusinessLayerInterfaces.BusinessModels;
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
			   .Select(Map)
			   .ToList();

			return viewModels;
		}

		public List<IndexViewModel> GetUsers(string search)
		{
			return _homeServices
				.GetUsersBySearchString(search)
				.Select(Map)
				.ToList();
		}

		private IndexViewModel Map(UserBlm userBlm)
		{
			return new IndexViewModel
			{
				Id = userBlm.Id,
				Name = userBlm.Name,
				FavoriteMovieName = userBlm.FavoriteMovieName
			};
		}
	}
}
