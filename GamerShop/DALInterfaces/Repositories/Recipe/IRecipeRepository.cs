using DALInterfaces.DataModels.Recipe;
using DALInterfaces.Models.Recipe;

namespace DALInterfaces.Repositories.Recipe
{
    public interface IRecipeRepository : IBaseRepository<Models.Recipe.Recipe>
    {
        void AddFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel);
        void RemoveFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel);
        PaginatorRecipeDataModel GetPaginatorRecipeDataModel(int page, int perPage);
        IEnumerable<Models.Recipe.Recipe> GetFavoriteByUser(int currentUserId);
    }
}
