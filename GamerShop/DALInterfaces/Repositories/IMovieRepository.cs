using DALInterfaces.Models;

namespace DALInterfaces.Repositories;

public interface IMovieRepository : IBaseRepository<Movie>
{
    void ChooseFavorite(int currentUserId, int movieId);
}