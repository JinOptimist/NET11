using DALInterfaces.Models.Movies;

namespace DALInterfaces.Repositories.Movies;

public interface ICollectionRepository : IBaseRepository<Collection>
{
    IEnumerable<Collection> GetLimitedCollectionSortedByCriteria(int count,
        Func<Collection, IComparable> sortingCriteria);
}