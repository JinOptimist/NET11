using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
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
				.Select(x => new UserBlm
				{
					Id = x.Id,
					Name = x.Name,
				});

		public UserBlm GetUserById(int id)
		{
			var userDb = _userRepository.Get(id);
			return new UserBlm
			{
				Id = userDb.Id,
				Name = userDb.Name,
			};
		}
	}
}
