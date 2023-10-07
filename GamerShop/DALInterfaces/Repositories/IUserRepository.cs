using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAdultUsers();

		int? GetUserIdByNameAndPassword(string userName, string password);

        IEnumerable<Models.Recipe.Recipe> GetFavoriteByUser(int userId);
        bool IsUserNameExist(string name);
		IEnumerable<User> GetUsersBySearchString(string search, int count);
        User? GetUserByName(string name);

	}
}
