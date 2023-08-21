using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(WebContext context) : base(context)
        {
        }
    }
}
