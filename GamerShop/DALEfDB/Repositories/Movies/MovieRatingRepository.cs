using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class MovieRatingRepository : BaseRepository<Rating>, IMovieRatingRepository
{
    public MovieRatingRepository(WebContext context) : base(context)
    {
    }
}