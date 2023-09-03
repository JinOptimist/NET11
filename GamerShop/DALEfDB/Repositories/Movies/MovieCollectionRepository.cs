using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class MovieCollectionRepository : BaseRepository<Collection>, IMovieCollectionRepository
{
    public MovieCollectionRepository(WebContext context) : base(context)
    {
    }

    public IEnumerable<T> GetLimitedMovieCollectionsSortedByCriteria<T>(int count,
        Func<Collection, IComparable> sortingCriteria, Func<Collection, T> projection)
    {
        if (projection == null)
        {
            throw new ArgumentNullException(nameof(projection));
        }


        return _dbSet
            .OrderByDescending(sortingCriteria)
            .Take(count)
            .Select(collection =>
                {
                    var result = projection(collection);
                    if (!(result is T))
                    {
                        throw new InvalidOperationException($"Projection function must return a value of type {typeof(T)}.");
                    }
                    return result;
                })
            .ToList();
    }
}