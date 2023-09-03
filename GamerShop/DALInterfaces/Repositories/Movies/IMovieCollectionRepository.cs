using DALInterfaces.DataModels.Movies;
using DALInterfaces.Models.Movies;

namespace DALInterfaces.Repositories.Movies;

public interface IMovieCollectionRepository : IBaseRepository<Collection>
{
    IEnumerable<T> GetLimitedMovieCollectionsSortedByCriteria<T>(int count,
        Func<Collection, IComparable> sortingCriteria, Func<Collection, T> projection);

    MovieCollectionPaginatorDataModel GetMovieCollectionPaginatorDataModel(int page, int perPage);
}