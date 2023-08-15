using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected static List<DbModel> _entyties = new List<DbModel>();

        public virtual IEnumerable<DbModel> GetAll()
        {
            return _entyties;
        }

        public virtual void Save(DbModel model)
        {
            var maxCurrentId = _entyties.Any()
                ? _entyties.Max(x => x.Id)
                : 0;
            model.Id = maxCurrentId + 1;
            _entyties.Add(model);
        }

        public virtual void Remove(int id)
        {
            var enity = _entyties.FirstOrDefault(x => x.Id == id);
            _entyties.Remove(enity);
        }

		public DbModel Get(int id)
		{
			return _entyties.FirstOrDefault(x => x.Id == id);
		}
	}
}
