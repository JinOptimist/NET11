using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Repositories;

namespace BusinessLayer.MovieServices;

public class RemoveMovieServices : IRemoveServices
{
    private readonly IMovieRepository _movieRepository;

    public RemoveMovieServices(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void Remove(int id)
    {
        _movieRepository.Remove(id);
    }
}