using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private static List<Recipe> _recipe = new List<Recipe>();

        public IEnumerable<Recipe> GetAll()
        {
            return _recipe;
        }

		public void Remove(int id)
		{
			var recipe = _recipe.FirstOrDefault(x => x.Id == id);
            _recipe.Remove(recipe);
		}

		public void Save(Recipe recipe)
        {
            _recipe.Add(recipe);
        }
    }
}
