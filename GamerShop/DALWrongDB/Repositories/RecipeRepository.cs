using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories.Recipe;

namespace DALWrongDB.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {

    }
}
