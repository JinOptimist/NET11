using DALInterfaces.DataModels.Recipe;
using DALInterfaces.Repositories.Recipe;
using Microsoft.Extensions.Configuration;

namespace DALEfDB.Repositories.Recipe
{
    public class RecipeRepository : BaseRepository<DALInterfaces.Models.Recipe.Recipe>, IRecipeRepository
    {
        public RecipeRepository(WebContext context) : base(context)
        { }

        public void AddFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel)
        {
            _dbSet
                .First(recipe => recipe.Id == favoriteRecipeDataModel.Recipe.Id)
                .UsersWhoLikeIt
                .Add(favoriteRecipeDataModel.User);
            _context.SaveChanges();
        }

        public void RemoveFavorite(FavoriteRecipeDataModel favoriteRecipeDataModel)
        {
            _dbSet
                .First(recipe => recipe.Id == favoriteRecipeDataModel.Recipe.Id)
                .UsersWhoLikeIt
                .Remove(favoriteRecipeDataModel.User);
            _context.SaveChanges();
        }
    }
}
