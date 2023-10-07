using DALInterfaces.DataModels;
using DALInterfaces.Models;
using System.Linq.Expressions;

namespace DALInterfaces.Repositories
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
		DbModel Get(int id);

		IEnumerable<DbModel> GetAll();

        void Save(DbModel model);

        void Remove(int id);

		void Update(DbModel model);

		int Count();

        void SaveRange(IEnumerable<DbModel> models);

        PaginatorDataModel<DataModelTemplate> GetPaginatorDataModel<DataModelTemplate>(
            Func<DbModel, DataModelTemplate> map,
            int page,
            int perPage);

        PaginatorDataModel<DataModelTemplate> GetPaginatorDataModelWithFilter<DataModelTemplate>(
            Func<DbModel, DataModelTemplate> map,
            Expression<Func<DbModel, bool>> filter,
            int page,
            int perPage);

        DbModel GetLast();

        bool Any();
    }
}
