﻿using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.UserServices
{
	public class HomeServices : IHomeServices
	{
		private IUserRepository _userRepository;

		public HomeServices(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<UserBlm> GetLastLoginUsers()
			=> _userRepository
				.GetAll()
				.Take(5)
				.Select(Map);

		public UserBlm GetUserById(int id)
		{
			var userDb = _userRepository.Get(id);
			return new UserBlm
			{
				Id = userDb.Id,
				Name = userDb.Name,
			};
		}

		public IEnumerable<UserBlm> GetUsersBySearchString(string search, int count = 5)
			=> _userRepository
				.GetUsersBySearchString(search, count)
				.Select(Map);

		private UserBlm Map(User user)
		{
			return new UserBlm
			{
				Id = user.Id,
				Name = user.Name,
				FavoriteMovieName = user.FavoriteMovie?.Title ?? "---"
			};
		}
	}
}
