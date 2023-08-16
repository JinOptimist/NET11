using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private WebContext _context;

        public UserRepository(WebContext context)
        {
            _context = context;
        }

        public User Get(int id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public IEnumerable<User> GetAdultUsers()
        {
            return _context
                .Users
                .Where(x => x.Birthday < DateTime.Now.AddYears(-18))
                .ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _context
                .Users
                .ToList();
        }

        public User GetUserByNameAndPassword(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }

        public void Remove(int id)
        {
            _context.Users.Remove(Get(id));
            _context.SaveChanges();
        }

        public void Save(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }
    }
}
