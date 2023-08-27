using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.MovieServices;

public interface IMovieServices
{
    void Add(MovieBlm movieBlm);
    void Remove(int id);
    IEnumerable<MovieBlm> GetAllMovies();
    void ChooseFavorite(int currentUserId, int movieId);
}