using DALInterfaces.DataModels;
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

        public PaginatorRecipeDataModel GetPaginatorRecipeDataModel(int page, int perPage)
        {
			var count = _dbSet.Count();

			var recipes = _dbSet
				.Skip((page - 1) * perPage)
				.Take(perPage)
				.Select(dbRecipe => new RecipeDataModel
				{
					Id = dbRecipe.Id,
					Title = dbRecipe.Title,
					Description = dbRecipe.Title,
					Instructions = dbRecipe.Instructions,
					CookingTime = dbRecipe.CookingTime,
					PreparationTime = dbRecipe.PreparationTime,
					Servings = dbRecipe.Servings,
					DifficultyLevel = dbRecipe.DifficultyLevel,
					Cuisine = dbRecipe.Cuisine,
					CreatedByUserId = dbRecipe.CreatedByUserId,
					CreatedOn = dbRecipe.CreatedOn
				})
				.ToList();

			return new PaginatorRecipeDataModel
			{
				Count = count,
				Page = page,
				PerPage = perPage,
				Recipes = recipes
			};
		}

        public PaginatorFavoriteRecipeDataModel GetPaginatorFavoriteRecipeDataModel(int page, int perPage)
        {
	        throw new NotImplementedException();
        }

        public IEnumerable<DALInterfaces.Models.Recipe.Recipe> GetFavoriteByUser(int userId)
			=> _context.Users.First(user => user.Id == userId).FavoriteRecipes;

    }
}
