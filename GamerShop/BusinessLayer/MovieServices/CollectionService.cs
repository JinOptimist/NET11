using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Movies;

namespace BusinessLayer.MovieServices;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository _collectionRepository;
    private const int OTPUTCOUNT = 10;

    public CollectionService(ICollectionRepository collectionRepository, IMovieRepository movieRepository,
        IUserRepository userRepository)
    {
        _collectionRepository = collectionRepository;
    }


    public CollectionBlm GetCollectionById(int id)
    {
        var collection = _collectionRepository.Get(id);
        var shortMovieBlm = collection.Movies.Select(movie => new ShortMovieBlm
        {
            Id = movie.Id,
            Title = movie.Title
        }).ToList();

        var collectionBlm = new CollectionBlm
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
            .GetLimitedCollectionSortedByCriteria(OTPUTCOUNT, x => x.DateCreated)
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
}