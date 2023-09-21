using DALInterfaces.DataModels.Movies;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;
using Microsoft.EntityFrameworkCore;

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
            .Where(x=>x.IsPublic == true)       //ToDo: Подумать над универсальностью, может ли потребоваться для данного метода получать приватные записи и стоит ли вынести в переменную во входящий параметр определюющий включена ли фильтрация по публичным записям.
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

    protected override IQueryable<Collection> GetDbSetWithIncludeForPaginator()
    {
        return _context.Collections.Include(x => x.Ratings);
    }
}