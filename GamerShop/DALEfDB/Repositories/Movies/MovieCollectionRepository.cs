using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class MovieCollectionRepository : BaseRepository<Collection>, IMovieCollectionRepository
{
    public MovieCollectionRepository(WebContext context) : base(context)
    {
    }

    public IEnumerable<Collection> GetLimitedMovieCollectionSortedByCriteria(int count,
        Func<Collection, IComparable> sortingCriteria)
    {
        return _dbSet
            .OrderByDescending(sortingCriteria)
            .Take(count)
            .ToList();
    }
}