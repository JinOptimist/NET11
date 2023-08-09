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
            var maxCurrentId = _users.Any()
                ? _users.Max(x => x.Id)
                : 0;
            user.Id = maxCurrentId + 1;
            _users.Add(user);
        }

        public void Remove(int id)
        {
            var user = _users.SingleOrDefault(x => x.Id == id);
            _users.Remove(user);
        }
    }
}
