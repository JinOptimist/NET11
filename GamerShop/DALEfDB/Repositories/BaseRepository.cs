using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected WebContext _context;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(WebContext context)
        {
            _context = context;
            _dbSet = context.Set<DbModel>();
        }

        public DbModel Get(int id)
        {
            return _dbSet.First(x => x.Id == id);
        }

        public IEnumerable<DbModel> GetAll()
        {
            return _dbSet
                .ToList();
        }

        public void Remove(int id)
        {
            _dbSet.Remove(Get(id));
            _context.SaveChanges();
        }

        public void Save(DbModel model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
        }
    }
}
