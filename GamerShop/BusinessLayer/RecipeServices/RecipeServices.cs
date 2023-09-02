using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.BusinessModels.Users;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.DataModels.Recipe;
using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Recipe;

namespace BusinessLayer.RecipeServices
{
    public class RecipeServices : IRecipeServices
	{
		private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        public RecipeServices(IRecipeRepository recipeRepository, IUserRepository userRepository)
		{
			_recipeRepository = recipeRepository;
            _userRepository = userRepository;
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

		public void RemoveFavorite(FavoriteRecipeBlm favoriteRecipeBlm)
		{
            var favoriteRecipeDataModel = new FavoriteRecipeDataModel
            {
                User = _userRepository.Get(favoriteRecipeBlm.UserId),
                Recipe = _recipeRepository.Get(favoriteRecipeBlm.RecipeId)
            };

            _recipeRepository.RemoveFavorite(favoriteRecipeDataModel);
		}

		public IEnumerable<RecipeBlm> GetFavoriteByUser(int currentUserId)
		{
			return _recipeRepository.GetFavoriteByUser(currentUserId).Select(favoriteRecipe =>
			{
				var recipe = _recipeRepository.Get(favoriteRecipe.Id);
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

		public void AddFavorite(FavoriteRecipeBlm favoriteRecipeBlm)
        {
            var favoriteRecipeDataModel = new FavoriteRecipeDataModel
            {
                User = _userRepository.Get(favoriteRecipeBlm.UserId),
                Recipe = _recipeRepository.Get(favoriteRecipeBlm.RecipeId)
            };
            _recipeRepository.AddFavorite(favoriteRecipeDataModel);
        }

		public RecipeBlm GetRecipeById(int recipeId)
		{
			var recipeDb = _recipeRepository.Get(recipeId);
			return new RecipeBlm
			{
				Id = recipeDb.Id,
				Title = recipeDb.Title,
				Description = recipeDb.Title,
				Instructions = recipeDb.Instructions,
				CookingTime = recipeDb.CookingTime,
				PreparationTime = recipeDb.PreparationTime,
				Servings = recipeDb.Servings,
				DifficultyLevel = recipeDb.DifficultyLevel,
				Cuisine = recipeDb.Cuisine,
				CreatedByUserId = recipeDb.CreatedByUserId,
				CreatedOn = recipeDb.CreatedOn
			};
		}

        public PaginatorBlm<RecipeBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _recipeRepository.GetPaginatorDataModel(Map, page, perPage);
            return new PaginatorBlm<RecipeBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(x => new RecipeBlm()
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
                }).ToList()
            };
        }

		private RecipeDataModel Map(Recipe dbRecipe)
		{
			return new RecipeDataModel
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
			};
        }
    }
}
