using DALInterfaces.DataModels.Movies;
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

    public MovieCollectionPaginatorDataModel GetMovieCollectionPaginatorDataModel(int page, int perPage)
    {
        var count = _dbSet.Count();
        var collections = _dbSet
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .Select(collection => new ShortMovieCollectionDataModel
            {
                Id = collection.Id,
                Title = collection.Title,
                Description = collection.Description,
                DateCreated = collection.DateCreated,
                Rating = collection
                    .Ratings
                    .Where(rating => rating.CollectionId == collection.Id)
                    .Select(rating => rating.Value)
                    .DefaultIfEmpty(0)
                    .Average()
            })
            .ToList();

        var movieCollectionPaginatorDataModel = new MovieCollectionPaginatorDataModel()
        {
            Page = page,
            PerPage = perPage,
            Count = count,
            Collections = collections
        };
        return movieCollectionPaginatorDataModel;
    }
}