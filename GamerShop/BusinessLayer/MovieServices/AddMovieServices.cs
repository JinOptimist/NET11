using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.MovieServices;

public class AddMovieServices : IAddMovieServices
{
    private readonly IMovieRepository _movieRepository;

    public AddMovieServices(IMovieRepository movieRepository)
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
}