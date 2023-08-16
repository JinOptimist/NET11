using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository()
		{
			_entyties = new List<User>()
			{
				new User
				{
					Id = 1,
					Birthday = DateTime.Now,
					Name = "Admin",
					Password = "123"
				},
				new User
				{
					Id = 2,
					Birthday = DateTime.Now,
					Name = "User",
					Password = "123"
				},
			};
		}

		public IEnumerable<User> GetAdultUsers()
		{
			return _entyties.Where(x => x.Birthday < DateTime.Now.AddYears(-18));
		}

		public User GetUserByNameAndPassword(string userName, string password)
		{
			return _entyties.Single(x => x.Name == userName && x.Password == password);
		}
	}
}
