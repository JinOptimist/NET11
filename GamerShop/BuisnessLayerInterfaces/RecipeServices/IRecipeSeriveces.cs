using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.RecipeServices
{
    public interface IRecipeServices
    {
        IEnumerable<RecipeBlm> GetAll();
        void Save(RecipeBlm recipeBlm);
        void Remove(int id);
        void RemoveFavorite(int recipeId, int userId);
        IEnumerable<RecipeBlm> GetFavoriteByUser(int userId);
        void AddFavorite(int recipeId, int userId);
    }
}
