using DALInterfaces.DataModels;
using DALInterfaces.Models;
using System.Collections;

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
        PaginatorDataModel<DataModelTemplate> GetPaginatorDataModel<DataModelTemplate>(
           Func<DbModel, DataModelTemplate> map,
           int page,
           int perPage,
           IEnumerable<FilterDataModel> filters)
        {
            throw new NotImplementedException();
        }


        DbModel GetLast();

        bool Any();
    }
}
