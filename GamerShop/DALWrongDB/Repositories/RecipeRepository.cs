using DALInterfaces.DataModels.Recipe;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories.Recipe;

namespace DALWrongDB.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public void AddFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel)
        {
            throw new NotImplementedException();
        }
    }
}
