using DALInterfaces.DataModels;
using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAdultUsers();

		int? GetUserIdByNameAndPassword(string userName, string password);

		UserPaginatorDataModel GetUserPaginatorDataModel(int page, int perPage);
	}
}
