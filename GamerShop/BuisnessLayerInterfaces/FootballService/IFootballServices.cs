using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballServices <T> : IPaginatorServices<T> 
    {
        IEnumerable<T> GetAll();
        void Save(T item);
        void Delete(int id);
    }
}
