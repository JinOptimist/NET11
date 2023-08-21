using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public void ChooseFavorite(int currentUserId, int movieId)
    {
        throw new NotImplementedException();
    }
}