using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository {}