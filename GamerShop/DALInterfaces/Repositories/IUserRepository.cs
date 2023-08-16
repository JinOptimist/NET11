using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAdultUsers();

		User GetUserByNameAndPassword(string userName, string password);
	}
}
