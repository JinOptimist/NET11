using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class MovieGenreRepository : BaseRepository<Genre>, IMovieGenreRepository
{
    public MovieGenreRepository(WebContext context) : base(context)
    {
    }
}