using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Save(User user);
    }
}
