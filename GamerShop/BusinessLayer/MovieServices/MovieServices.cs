using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;

namespace BusinessLayer.MovieServices;

public class MovieServices : IMovieServices
{
    private readonly IMovieRepository _movieRepository;
    private readonly IUserRepository _userRepository;

    public MovieServices(IMovieRepository movieRepository, IUserRepository userRepository)
    {
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }

    public void Add(AddMovieBlm addMovieBlm)
    {
        var movieDb = new Movie()
        {
            Title = addMovieBlm.Title,
            CreatedDate = addMovieBlm.CreatedDate,
            UserId = addMovieBlm.UserId,
        };
        _movieRepository.Save(movieDb);
    }

    public void Remove(int id)
    {
        _movieRepository.Remove(id);
    }

    public IEnumerable<GetMovieBlm> GetAllMovies() => _movieRepository
        .GetAll()
        .Select(dbMovie => new GetMovieBlm()
        {
            Id = dbMovie.Id,
            Title = dbMovie.Title,
            DateCreated = dbMovie.CreatedDate,
            UserName = _userRepository.Get(dbMovie.UserId).Name
        });
}