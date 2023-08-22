using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Recipe;

namespace DALEfDB.Repositories.Recipe
{
    public class FavoriteRecipeRepository : BaseRepository<FavoriteRecipe>, IFavoriteRecipeRepository
	{
        public FavoriteRecipeRepository(WebContext context) : base(context)
        { }

        public void RemoveFavorite(FavoriteRecipe favoriteRecipe)
        {
            _dbSet.Remove(_dbSet.First(x => x.RecipeId == favoriteRecipe.RecipeId && x.UserId == favoriteRecipe.UserId));
            _context.SaveChanges();
        }

        public IEnumerable<FavoriteRecipe> GetFavoriteByUser(int currentUserId)
        {
	        return _dbSet.Where(recipe => recipe.UserId == currentUserId).ToList();
        }
        }
}
