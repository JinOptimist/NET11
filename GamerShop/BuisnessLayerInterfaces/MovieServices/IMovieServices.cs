using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieRepository
{
    MovieBlm GetMovieBlm(int id);
    List<ShortMovieBlmToAddInCollection> GetAvailableMoviesForSelection();
}