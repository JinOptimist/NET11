using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        void Save(Recipe recipe);

        void Remove(int id);
    }
}
