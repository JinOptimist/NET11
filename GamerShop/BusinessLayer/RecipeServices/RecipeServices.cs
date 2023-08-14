using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.Repositories;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.Models;

namespace BusinessLayer.RecipeServices
{
	public class RecipeServices : IRecipeServices

	{
		private IRecipeRepository _recipeRepository;

		public RecipeServices(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
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
					Cuisine = x.Cuisine
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
				Cuisine = recipeBlm.Cuisine
			};

			_recipeRepository.Save(dbRecipe);
		}

		public void Remove(int id)
		{
			_recipeRepository.Remove(id);
		}
	}
}
