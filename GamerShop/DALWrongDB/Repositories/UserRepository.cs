using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public IEnumerable<User> GetAdultUsers()
        {
            return _entyties.Where(x => x.Birthday < DateTime.Now.AddYears(-18));
        }
    }
}
