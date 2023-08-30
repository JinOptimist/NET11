using DALInterfaces.DataModels.Recipe;
using DALInterfaces.Models;

namespace DALInterfaces.Repositories.Recipe
{
    public interface IRecipeRepository : IBaseRepository<Models.Recipe.Recipe>
    {
        void AddFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel);
        void RemoveFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel);
    }
}
