using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballServices <T>
    {
        IEnumerable<T> GetAll();
        void Save(T item);
        void Delete(int id);
    }
}
