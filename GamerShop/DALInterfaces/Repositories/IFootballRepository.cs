using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IFootballRepository<T> : IBaseRepository<T> where T : BaseModel
    {

    }
}
