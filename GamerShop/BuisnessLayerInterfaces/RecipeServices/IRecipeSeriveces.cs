using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Recipe;

namespace BusinessLayerInterfaces.RecipeServices
{
    public interface IRecipeServices : IPaginatorServices<RecipeBlm, Recipe>
    {
        IEnumerable<RecipeBlm> GetAll();
        void Save(RecipeBlm recipeBlm);
        void Remove(int id);
        void RemoveFavorite(FavoriteRecipeBlm favoriteRecipeBlm);
        IEnumerable<RecipeBlm> GetFavoriteByUser(int userId);
        void AddFavorite(FavoriteRecipeBlm favoriteRecipeBlm);
        RecipeBlm GetRecipeById(int recipeId);
    }
}
