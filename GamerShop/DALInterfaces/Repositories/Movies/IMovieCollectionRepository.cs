using DALInterfaces.Models.Movies;

namespace DALInterfaces.Repositories.Movies;

public interface IMovieCollectionRepository : IBaseRepository<Collection>
{
    IEnumerable<Collection> GetLimitedMovieCollectionSortedByCriteria(int count,
        Func<Collection, IComparable> sortingCriteria);
}