using DALInterfaces.DataModels.Movies;
using DALInterfaces.Models.Movies;

namespace DALInterfaces.Repositories.Movies;

public interface IMovieRepository : IBaseRepository<Movie>
{
    List<ShortMovieDataModelToAddInCollection> GetMoviesForSelection();
    bool IsMovieExist(string title);
}