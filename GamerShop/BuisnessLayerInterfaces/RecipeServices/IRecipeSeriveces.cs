using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.RecipeServices
{
    public interface IRecipeServices
    {
        IEnumerable<RecipeBlm> GetAll();
        void Save(RecipeBlm recipeBlm);
        void Remove(int id);
    }
}
