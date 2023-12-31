﻿using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;

namespace GamerShop.Services
{
	public class AuthService : IAuthService
	{
		private IHomeServices _homeServices;
		private IHttpContextAccessor _httpContextAccessor;

		public AuthService(IHomeServices homeServices, IHttpContextAccessor httpContextAccessor)
		{
			_homeServices = homeServices;
			_httpContextAccessor = httpContextAccessor;
		}

        public string GetAvatar()
        {
			return $"/img/avatars/{GetIdStr()}.jpg";
        }

        public UserBlm GetCurrentUser()
		{
			var idStr = GetIdStr();
            var id = int.Parse(idStr);
			var user = _homeServices.GetUserById(id);
			return user;
		}

        public string GetUserName()
        {
            return _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Name")
                ?.Value;
        }

        public string GetIdStr()
		{
			return _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;
        }
	}
}
