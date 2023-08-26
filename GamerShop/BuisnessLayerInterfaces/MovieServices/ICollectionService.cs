using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface ICollectionService
{
    CollectionBlm GetCollectionById(int id);

    List<ShortCollectionBlm> GetShortCollectionSortedByDate();
}