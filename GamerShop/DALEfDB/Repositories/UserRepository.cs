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

        public IEnumerable<DALInterfaces.Models.Recipe.Recipe> GetFavoriteByUser(int userId)
        {
            return _dbSet.First(user => user.Id == userId).FavoriteRecipes;
        }
    }
}
