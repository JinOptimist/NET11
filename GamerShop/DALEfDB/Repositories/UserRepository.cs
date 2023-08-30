using DALInterfaces.DataModels;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(WebContext context) : base(context) { }

		public IEnumerable<User> GetAdultUsers()
		{
			return _dbSet
				.Where(x => x.Birthday < DateTime.Now.AddYears(-18))
				.ToList();
		}

		public int? GetUserIdByNameAndPassword(string userName, string password)
		{
			return _dbSet
				.FirstOrDefault(x => x.Name == userName && x.Password == password)
				?.Id;
		}

		public UserPaginatorDataModel GetUserPaginatorDataModel(int page, int perPage)
		{
			var count = _dbSet.Count();

			var users = _dbSet
				.Skip((page - 1) * perPage)
				.Take(perPage)
				.Select(dbUser => new UserDataModel
				{
					Id = dbUser.Id,
					Name = dbUser.Name,
					Birthday = dbUser.Birthday,
					FavoriteMovieName = dbUser.FavoriteMovie == null ? null : dbUser.FavoriteMovie.Title
				})
				.ToList();

			return new UserPaginatorDataModel
			{
				Count = count,
				Page = page,
				PerPage = perPage,
				Users = users
			};
		}
	}
}
