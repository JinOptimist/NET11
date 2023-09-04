using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.Common;
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

    public List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByCriteria(MovieCollectionSortCriteria filterCriteria)
    {
        //Данный метод предназначен для мапинга из Collection в ShortMovieCollectionDataModel. Оп передается в метод GetLimitedMovieCollectionsSortedByCriteria.
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

        switch (filterCriteria)
        {
            case MovieCollectionSortCriteria.Newest:
                //Данный метод определяет критерий сортировки, который далее передается в метод GetLimitedMovieCollectionsSortedByCriteria.
                IComparable GetSortingByDateCreated(Collection collection)
                    => collection.DateCreated;

                var shortMovieCollectionsBlmSortedByDate = _movieCollectionRepository
                    .GetLimitedMovieCollectionsSortedByCriteria(OTPUTCOUNT, GetSortingByDateCreated, MapToShortMovieCollectionDataModel)
                    .Select(collection => new ShortMovieCollectionBlm
                    {
                        Id = collection.Id,
                        Title = collection.Title,
                        Description = collection.Description,
                        DateCreated = collection.DateCreated,
                        Rating = collection.Rating
                    })
                    .ToList();
                return shortMovieCollectionsBlmSortedByDate;

            case MovieCollectionSortCriteria.Popular:
                //Данный метод определяет критерий сортировки, который далее передается в метод GetLimitedMovieCollectionsSortedByCriteria.
                IComparable GetSortingByRating(Collection collection)
                    => collection
                        .Ratings.Where(rating => rating.CollectionId == collection.Id)
                        .Select(rating => rating.Value)
                        .DefaultIfEmpty(0)
                        .Average();

                var shortMovieCollectionsBlmSortedByRating = _movieCollectionRepository
                    .GetLimitedMovieCollectionsSortedByCriteria(OTPUTCOUNT, GetSortingByRating, MapToShortMovieCollectionDataModel)
                    .Select(collection => new ShortMovieCollectionBlm
                    {
                        Id = collection.Id,
                        Title = collection.Title,
                        Description = collection.Description,
                        DateCreated = collection.DateCreated,
                        Rating = collection.Rating
                    })
                    .ToList();
                return shortMovieCollectionsBlmSortedByRating;

            default:
                throw new ArgumentException("Неподдерживаемый критерий сортировки", nameof(filterCriteria));
        }
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

    public MovieCollectionPaginatorBlm GetMovieCollectionPaginatorBlm(int page, int perPage)
    {
        var movieCollectionPaginatorDataModel = _movieCollectionRepository.GetMovieCollectionPaginatorDataModel(page, perPage);
        return new MovieCollectionPaginatorBlm()
        {
            Page = movieCollectionPaginatorDataModel.Page,
            PerPage = movieCollectionPaginatorDataModel.PerPage,
            Count = movieCollectionPaginatorDataModel.Count,
            Collections = movieCollectionPaginatorDataModel
                .Collections
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

    public PaginatorBlm<ShortMovieCollectionBlm> GetPaginatorBlm(int page, int perPage)
    {
        var movieCollectionPaginatorDataModel = _movieCollectionRepository.GetMovieCollectionPaginatorDataModel(page, perPage);
        return new PaginatorBlm<ShortMovieCollectionBlm>()
        {
            Page = movieCollectionPaginatorDataModel.Page,
            PerPage = movieCollectionPaginatorDataModel.PerPage,
            Count = movieCollectionPaginatorDataModel.Count,
            Items = movieCollectionPaginatorDataModel
                .Collections
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
}