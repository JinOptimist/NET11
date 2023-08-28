using BusinessLayerInterfaces.BusinessModels.Movies;

namespace BusinessLayerInterfaces.MovieServices;

public interface ICollectionService
{
    CollectionBlmForShow GetCollectionById(int id);

    List<ShortCollectionBlm> GetShortCollectionSortedByDate();

    void CreateCollection(CollectionBlmForCreate collectionBlmForCreate);
}