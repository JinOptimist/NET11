using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Repositories;
using GamerShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsExistUsername(string name)
        {
            Thread.Sleep(2 * 1000);
            return _userService.IsUserNameExist(name);
        }
    }
}
