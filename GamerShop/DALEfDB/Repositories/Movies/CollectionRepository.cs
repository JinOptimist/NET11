using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class CollectionRepository : BaseRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(WebContext context) : base(context) {}

    public IEnumerable<Collection> GetLimitedCollectionSortedByCriteria(int count, Func<Collection, IComparable> sortingCriteria) =>
        _dbSet
            .OrderByDescending(sortingCriteria)
            .Take(count)
            .ToList();
}