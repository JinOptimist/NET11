using System.Linq.Expressions;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.MovieServices;
using DALInterfaces.DataModels.Movies;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Movies;

namespace BusinessLayer.MovieServices;

public class MovieCollectionService : IMovieCollectionService
{
    private readonly IMovieCollectionRepository _movieCollectionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;

    private const int OUTPUTLIMIT = 10;

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
                .Select(r => r.Value)
                .DefaultIfEmpty(0)
                .Average()
        };
        return movieCollectionBlmForShow;
    }

    public void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate)
    {
        var movieCollectionToAdd = new Collection
        {
            Title = movieCollectionBlmForCreate.Title,
            Description = movieCollectionBlmForCreate.Description,
            DateCreated = DateTime.Now,
            IsPublic = movieCollectionBlmForCreate.IsPublic,
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

    public PaginatorBlm<ShortMovieCollectionBlm> GetPaginatorBlm(int page, int perPage)
    {
        var movieCollectionPaginatorDataModel = _movieCollectionRepository.GetPaginatorDataModel(Map, page, perPage);
        return new PaginatorBlm<ShortMovieCollectionBlm>()
        {
            Page = movieCollectionPaginatorDataModel.Page,
            PerPage = movieCollectionPaginatorDataModel.PerPage,
            Count = movieCollectionPaginatorDataModel.Count,
            Items = movieCollectionPaginatorDataModel
                .Items
                .Select(m => new ShortMovieCollectionBlm
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    DateCreated = m.DateCreated,
                    Rating = m.Rating
                })
                .ToList()
        };
    }


    public PaginatorBlm<ShortMovieCollectionBlm> GetPaginatorBlmWithFilter(
        Expression<Func<Collection, bool>> filter,
        string sortingCriteria,
        int page,
        int perPage,
        bool isAscending)
    {
        Func<Collection, IComparable> funcSortingCriteria;

        switch (sortingCriteria)
        {
            case "Newest":
                funcSortingCriteria = collection =>
                    collection
                        .DateCreated;
                break;

            case "Popular":
                funcSortingCriteria = collection =>
                    collection
                        .Ratings
                        .Where(rating => rating.CollectionId == collection.Id)
                        .Select(rating => rating.Value)
                        .DefaultIfEmpty(0)
                        .Average();
                break;

            case "Alphabetically":
                funcSortingCriteria = collection =>
                    collection
                        .Title;
                break;

            default:
                throw new ArgumentException("Неподдерживаемый критерий сортировки", nameof(sortingCriteria));
        }
        var movieCollectionPaginatorDataModel = _movieCollectionRepository
            .GetPaginatorDataModelWithFilter(Map, filter, page, perPage, funcSortingCriteria, isAscending);

        return new PaginatorBlm<ShortMovieCollectionBlm>()
        {
            Page = movieCollectionPaginatorDataModel.Page,
            PerPage = movieCollectionPaginatorDataModel.PerPage,
            Count = movieCollectionPaginatorDataModel.Count,
            Items = movieCollectionPaginatorDataModel
                .Items
                .Select(m => new ShortMovieCollectionBlm
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    DateCreated = m.DateCreated,
                    Rating = m.Rating
                })
                .ToList()
        };
    }

    private ShortMovieCollectionDataModel Map(Collection collection)
    {
        return new ShortMovieCollectionDataModel
        {
            Id = collection.Id,
            Title = collection.Title,
            Description = collection.Description,
            DateCreated = collection.DateCreated,
            Rating = collection.Ratings.Count == 0
                ? 0
                : collection
                    .Ratings
                    .Select(rating => rating.Value)
                    .Average()
        };
    }

    public List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByCriteria(string filterCriteria)
    {
        ShortMovieCollectionDataModel MapToShortMovieCollectionDataModel(Collection collection) =>
            new()
            {
                Id = collection.Id,
                Title = collection.Title,
                Description = collection.Description,
                DateCreated = collection.DateCreated,
                Rating = collection.Ratings.Where(rating => rating.CollectionId == collection.Id)
                    .Select(rating => rating.Value)
                    .DefaultIfEmpty(0)
                    .Average()
            };

        Func<Collection, IComparable> sortingCriteria;

        switch (filterCriteria)
        {
            case "Newest":
                sortingCriteria = collection => collection.DateCreated;
                break;

            case "Popular":
                sortingCriteria = collection =>
                    collection
                        .Ratings
                        .Where(rating => rating.CollectionId == collection.Id)
                        .Select(rating => rating.Value)
                        .DefaultIfEmpty(0)
                        .Average();
                break;

            default:
                throw new ArgumentException("Неподдерживаемый критерий сортировки", nameof(filterCriteria));
        }

        return _movieCollectionRepository
            .GetLimitedMovieCollectionsSortedByCriteria(OUTPUTLIMIT, sortingCriteria, MapToShortMovieCollectionDataModel)
            .Select(collection => new ShortMovieCollectionBlm
            {
                Id = collection.Id,
                Title = collection.Title,
                Description = collection.Description,
                DateCreated = collection.DateCreated,
                Rating = collection.Rating
            })
            .ToList();
    }
}