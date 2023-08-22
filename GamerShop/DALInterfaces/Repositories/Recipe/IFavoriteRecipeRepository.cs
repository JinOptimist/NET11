using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;

namespace DALInterfaces.Repositories.Recipe
{
	public interface IFavoriteRecipeRepository : IBaseRepository<FavoriteRecipe>
	{
		void RemoveFavorite(FavoriteRecipe favoriteRecipe);
		IEnumerable<FavoriteRecipe> GetFavoriteByUser(int currentUserId);
	}
}
