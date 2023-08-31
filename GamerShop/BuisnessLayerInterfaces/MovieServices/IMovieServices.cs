using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieServices
{
    MovieBlm GetMovieBlm(int id);
    List<ShortMovieBlmToAddInCollection> GetAvailableMoviesForSelection();
}