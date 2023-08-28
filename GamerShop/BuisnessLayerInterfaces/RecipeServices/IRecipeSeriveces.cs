using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.RecipeServices
{
    public interface IRecipeServices : IPaginatorServices<RecipeBlm>
    {
        IEnumerable<RecipeBlm> GetAll();
        void Save(RecipeBlm recipeBlm);
        void Remove(int id);
        void RemoveFavorite(FavoriteRecipeBlm favoriteRecipeBlm);
        IEnumerable<RecipeBlm> GetFavoriteByUser(int userId);
        void AddFavorite(FavoriteRecipeBlm favoriteRecipeBlm);
        PaginatorRecipeBlm GetPaginatorRecipeBlm(int page, int perPage);
        RecipeBlm GetRecipeById(int recipeId);
    }
}
