using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class RatingRepository : BaseRepository<Rating>, IRatingRepository
{
    public RatingRepository(WebContext context) : base(context) { }
}