using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieServices
{
    void Add(AddMovieBlm addMovieBlm);
    void Remove(int id);
    IEnumerable<GetMovieBlm> GetAllMovies();
}