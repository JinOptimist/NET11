using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieCollectionService
{
    MovieCollectionBlmForShow GetMovieCollectionById(int id);

    List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByCriteria(MovieCollectionSortCriteria filterCriteria);

    void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate);

    MovieCollectionPaginatorBlm GetMovieCollectionPaginatorBlm(int page, int perPage);
}