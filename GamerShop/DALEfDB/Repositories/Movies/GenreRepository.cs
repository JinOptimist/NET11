using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(WebContext context) : base(context){}
}