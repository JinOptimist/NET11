using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Repositories;

namespace BusinessLayer.MovieServices;

public class ShowMovieServices : IShowMovieServices
{
    private readonly IMovieRepository _movieRepository;

    public ShowMovieServices(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public IEnumerable<MovieBlm> GetAllMovies() => _movieRepository
        .GetAll()
        .Select(dbMovie => new MovieBlm()
        {
            Id = dbMovie.Id,
            Title = dbMovie.Title
        });
}