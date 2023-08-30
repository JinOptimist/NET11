using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Movies;

namespace BusinessLayer.MovieServices;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;

    private const int OTPUTCOUNT = 10;

    public CollectionService(ICollectionRepository collectionRepository, IMovieRepository movieRepository,
        IUserRepository userRepository)
    {
        _collectionRepository = collectionRepository;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }


    public CollectionBlmForShow GetCollectionById(int id)
    {
        var collection = _collectionRepository.Get(id);
        var shortMovieBlm = collection.Movies.Select(movie => new ShortMovieBlm
        {
            Id = movie.Id,
            Title = movie.Title
        }).ToList();

        var collectionBlm = new CollectionBlmForShow
        {
            Id = collection.Id,
            Title = collection.Title,
            Description = collection.Description,
            DateCreated = collection.DateCreated,
            AuthorName = collection.Author.Name,
            Movies = shortMovieBlm,
            Rating = collection
                .Ratings
                .Where(rating => rating.CollectionId == collection.Id)
                .Select(r => r.Value)
                .DefaultIfEmpty(0)
                .Average()
        };
        return collectionBlm;
    }

    public List<ShortCollectionBlm> GetShortCollectionSortedByDate()
    {
        var shortCollectionBlms = _collectionRepository
            .GetLimitedCollectionSortedByCriteria(OTPUTCOUNT, collection => collection.DateCreated)
            .Select(collection => new ShortCollectionBlm
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
        return shortCollectionBlms;
    }

    public void CreateCollection(CollectionBlmForCreate collectionBlmForCreate)
    {
        var collectionToAdd = new Collection
        {
            Title = collectionBlmForCreate.Title,
            Description = collectionBlmForCreate.Description,
            DateCreated = DateTime.Now,
            AuthorId = collectionBlmForCreate.Author.Id,
            Author = _userRepository.Get(collectionBlmForCreate.Author.Id),
            Movies = collectionBlmForCreate
                .MoviesIds
                .Select(m=>_movieRepository.Get(m))
                .ToList(),
            Ratings = new List<Rating>(),
        };
        _collectionRepository.Save(collectionToAdd);
    }
}