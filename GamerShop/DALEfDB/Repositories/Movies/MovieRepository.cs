using DALInterfaces.DataModels.Movies;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories.Movies;

namespace DALEfDB.Repositories.Movies
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(WebContext context) : base(context) { }

        public List<ShortMovieDataModelToAddInCollection> GetMoviesForSelection()
        {
            return _dbSet.
                Select(m => new ShortMovieDataModelToAddInCollection()
                {
                    Id = m.Id,
                    Title = m.Title,
                })
                .ToList();
        }

        public bool IsMovieExist(string title)
            => _dbSet.Any(x => x.Title == title);
    }
}
