using DALInterfaces.Models;

namespace DALInterfaces.Repositories;

public interface IMovieRepository
{
    void Save(Movie movie);
    IEnumerable<Movie> GetAll();
    void Remove(int id);
}