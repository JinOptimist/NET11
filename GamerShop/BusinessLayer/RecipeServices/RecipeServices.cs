using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories.Recipe;

namespace BusinessLayer.RecipeServices
{
	public class RecipeServices : IRecipeServices
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IFavoriteRecipeRepository _favoriteRecipeRepository;

		public RecipeServices(IRecipeRepository recipeRepository, IFavoriteRecipeRepository favoriteRecipeRepository)
		{
			_recipeRepository = recipeRepository;
			_favoriteRecipeRepository = favoriteRecipeRepository;
		}

		public IEnumerable<RecipeBlm> GetAll()
			=> _recipeRepository
				.GetAll()
				.Select(x => new RecipeBlm()
				{
					Id = x.Id,
					Title = x.Title,
					Description = x.Title,
					Instructions = x.Instructions,
					CookingTime = x.CookingTime,
					PreparationTime = x.PreparationTime,
					Servings = x.Servings,
					DifficultyLevel = x.DifficultyLevel,
					Cuisine = x.Cuisine,
					CreatedByUserId = x.CreatedByUserId,
					CreatedOn = x.CreatedOn
				});


		public void Save(RecipeBlm recipeBlm)
		{
			var dbRecipe = new Recipe()
			{
				Title = recipeBlm.Title,
				Description = recipeBlm.Title,
				Instructions = recipeBlm.Instructions,
				CookingTime = recipeBlm.CookingTime,
				PreparationTime = recipeBlm.PreparationTime,
				Servings = recipeBlm.Servings,
				DifficultyLevel = recipeBlm.DifficultyLevel,
				Cuisine = recipeBlm.Cuisine,
				CreatedByUserId = recipeBlm.CreatedByUserId,
				CreatedOn = recipeBlm.CreatedOn
			};

			_recipeRepository.Save(dbRecipe);
		}

		public void Remove(int id)
		{
			_recipeRepository.Remove(id);
		}

		public void RemoveFavorite(int resipeId, int userId)
		{

			_favoriteRecipeRepository.RemoveFavorite(resipeId, userId);
		}

		public IEnumerable<RecipeBlm> GetFavoriteByUser(int currentUserId)
		{
			return _favoriteRecipeRepository.GetFavoriteByUser(currentUserId).Select(favoriteRecipe =>
			{
				var recipe = _recipeRepository.Get(favoriteRecipe.RecipeId);
				return new RecipeBlm()
				{
					Id = recipe.Id,
					Title = recipe.Title,
					Description = recipe.Title,
					Instructions = recipe.Instructions,
					CookingTime = recipe.CookingTime,
					PreparationTime = recipe.PreparationTime,
					Servings = recipe.Servings,
					DifficultyLevel = recipe.DifficultyLevel,
					Cuisine = recipe.Cuisine,
					CreatedByUserId = recipe.CreatedByUserId,
					CreatedOn = recipe.CreatedOn
				};
			});
		}

		public void AddFavorite(int recipeId, int userId)
		{
			_favoriteRecipeRepository.Save(new FavoriteRecipe()
			{
				RecipeId = recipeId,
				UserId = userId
			});
		}
	}
}
