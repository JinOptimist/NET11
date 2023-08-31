using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Repositories.Movies;

namespace BusinessLayer.MovieServices;

public class MovieServices : IMovieServices
{
    private readonly IMovieRepository _movieRepository;

    public MovieServices(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public MovieBlm GetMovieBlm(int id)
    {
        var movieDataModel = _movieRepository.Get(id);
        var movieBlm = new MovieBlm
        {
            Title = movieDataModel.Title,
            Description = movieDataModel.Description,
            ReleaseYear = movieDataModel.ReleaseYear,
            Director = movieDataModel.Director,
            Rating = movieDataModel.Rating,
            Country = movieDataModel.Country,
            Duration = movieDataModel.Duration,
            Genres = string
                .Join(", ", movieDataModel
                    .Genres
                    .Select(c => c.Name)
                    .ToList())
        };
        return movieBlm;
    }

    public List<ShortMovieBlmToAddInCollection> GetAvailableMoviesForSelection()
    {
        var moviesForSelection = _movieRepository.GetMoviesForSelection();
        var movieBlmToAddInCollections = moviesForSelection
            .Select(m => new ShortMovieBlmToAddInCollection
            {
                Id = m.Id,
                Title = m.Title
            })
            .ToList();
        return movieBlmToAddInCollections;
    }
}