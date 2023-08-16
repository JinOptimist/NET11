using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
		DbModel Get(int id);

		IEnumerable<DbModel> GetAll();

        void Save(DbModel model);

        void Remove(int id);
    }
}
