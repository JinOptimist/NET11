using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories;

public class MovieRepository : IMovieRepository
{
    private static readonly List<Movie> Movies = new();

    public void Save(Movie movie)
    {
        var maxCurrentId = Movies.Any()
            ? Movies.Max(x => x.Id)
            : 0;

        movie.Id = maxCurrentId + 1;
        Movies.Add(movie);
    }

    public IEnumerable<Movie> GetAll()
    {
        return Movies;
    }

    public void Remove(int id)
    {
        var movieToRemove = Movies.SingleOrDefault(movie => movie.Id == id);
        if (movieToRemove != null) Movies.Remove(movieToRemove);
    }
}