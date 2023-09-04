using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieCollectionService : IPaginatorServices<ShortMovieCollectionBlm>
{
    MovieCollectionBlmForShow GetMovieCollectionById(int id);

    List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByCriteria(MovieCollectionSortCriteria filterCriteria);

    void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate);
}