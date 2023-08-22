using DALInterfaces.Repositories.Recipe;

namespace DALEfDB.Repositories.Recipe
{
    public class RecipeRepository : BaseRepository<DALInterfaces.Models.Recipe.Recipe>, IRecipeRepository
    {
        public RecipeRepository(WebContext context) : base(context)
        { }
    }
}
