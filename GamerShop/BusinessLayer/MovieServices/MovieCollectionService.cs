using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Movies;

namespace BusinessLayer.MovieServices;

public class MovieCollectionService : IMovieCollectionService
{
    private readonly IMovieCollectionRepository _movieCollectionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;

    private const int OTPUTCOUNT = 10;

    public MovieCollectionService(IMovieCollectionRepository movieCollectionRepository,
        IMovieRepository movieRepository,
        IUserRepository userRepository)
    {
        _movieCollectionRepository = movieCollectionRepository;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }


    public MovieCollectionBlmForShow GetMovieCollectionById(int id)
    {
        var movieCollection = _movieCollectionRepository.Get(id);
        var shortMovieBlm = movieCollection
            .Movies
            .Select(movie => new ShortMovieBlm
            {
                Id = movie.Id,
                Title = movie.Title
            }).ToList();

        var movieCollectionBlmForShow = new MovieCollectionBlmForShow
        {
            Id = movieCollection.Id,
            Title = movieCollection.Title,
            Description = movieCollection.Description,
            DateCreated = movieCollection.DateCreated,
            AuthorName = movieCollection.Author.Name,
            Movies = shortMovieBlm,
            Rating = movieCollection
                .Ratings
                .Where(rating => rating.CollectionId == movieCollection.Id)
                .Select(r => r.Value)
                .DefaultIfEmpty(0)
                .Average()
        };
        return movieCollectionBlmForShow;
    }

    public List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByDate()
    {
        var shortMovieCollectionBlms = _movieCollectionRepository
            .GetLimitedMovieCollectionSortedByCriteria(OTPUTCOUNT, collection => collection.DateCreated)
            .Select(collection => new ShortMovieCollectionBlm
            {
                Id = collection.Id,
                Title = collection.Title,
                Description = collection.Description,
                DateCreated = collection.DateCreated,
                Rating = collection
                    .Ratings
                    .Where(rating => rating.CollectionId == collection.Id)
                    .Select(rating => rating.Value)
                    .DefaultIfEmpty(0)
                    .Average()
            })
            .ToList();
        return shortMovieCollectionBlms;
    }

    public void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate)
    {
        var movieCollectionToAdd = new Collection
        {
            Title = movieCollectionBlmForCreate.Title,
            Description = movieCollectionBlmForCreate.Description,
            DateCreated = DateTime.Now,
            AuthorId = movieCollectionBlmForCreate.Author.Id,
            Author = _userRepository.Get(movieCollectionBlmForCreate.Author.Id),
            Movies = movieCollectionBlmForCreate
                .MoviesIds
                .Select(m => _movieRepository.Get(m))
                .ToList(),
            Ratings = new List<Rating>()
        };
        _movieCollectionRepository.Save(movieCollectionToAdd);
    }
}