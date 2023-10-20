using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Movies;

namespace BusinessLayerInterfaces.MovieServices;

/// <summary>
/// Interface for movie collection management services.
/// Extends the IPaginatorServices interface to support pagination and filtering of movie collections.
/// </summary>
public interface IMovieCollectionService : IPaginatorServices<ShortMovieCollectionBlm, Collection>
{
    /// <summary>
    /// Get information about a movie collection by its ID.
    /// </summary>
    /// <param name="id">Movie collection identifier.</param>
    /// <returns>A MovieCollectionBlmForShow object that represents information about a movie collection.</returns>
    MovieCollectionBlmForShow GetMovieCollectionById(int id);

    /// <summary>
    /// Get a list of brief information about movie collections, sorted by specified criteria.
    /// </summary>
    /// <param name="filterCriteria">Sorting criteria for a list of movie collections.</param>
    /// <returns>A list of ShortMovieCollectionBlm representing brief information about movie collections.</returns>
    List<ShortMovieCollectionBlm> GetShortMovieCollectionSortedByCriteria(string filterCriteria);

    /// <summary>
    /// Create a new collection of movies with the given data.
    /// </summary>
    /// <param name="movieCollectionBlmForCreate">Объект MovieCollectionBlmForCreate, содержащий данные для создания коллекции фильмов.</param>
    void CreateMovieCollection(MovieCollectionBlmForCreate movieCollectionBlmForCreate);
}