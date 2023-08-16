using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.MovieServices;

public interface IShowMovieServices
{
    IEnumerable<MovieBlm> GetAllMovies();
}