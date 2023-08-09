using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Save(User user)
        {
            _users.Add(user);
        }
    }
}
