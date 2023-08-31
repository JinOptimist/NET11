using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieCollectionService
{
    MovieCollectionBlmForShow GetMovieCollectionById(int id);

    List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByDate();

    void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate);
}