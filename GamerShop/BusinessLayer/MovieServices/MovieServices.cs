using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.MovieServices;

public class MovieServices : IMovieServices
{
    private readonly IMovieRepository _movieRepository;

    public MovieServices(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void Add(MovieBlm movieBlm)
    {
        var movieDb = new Movie()
        {
            Title = movieBlm.Title,
            CreatedDate = movieBlm.CreatedDate
        };
        _movieRepository.Save(movieDb);
    }

    public void Remove(int id)
    {
        _movieRepository.Remove(id);
    }

    public IEnumerable<MovieBlm> GetAllMovies() => _movieRepository
        .GetAll()
        .Select(dbMovie => new MovieBlm()
        {
            Id = dbMovie.Id,
            Title = dbMovie.Title
        });

    public void ChooseFavorite(int currentUserId, int movieId)
        => _movieRepository.ChooseFavorite(currentUserId, movieId);
}