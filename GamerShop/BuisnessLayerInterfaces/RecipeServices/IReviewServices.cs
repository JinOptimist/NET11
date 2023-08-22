using BusinessLayerInterfaces.BusinessModels.Recipe;

namespace BusinessLayerInterfaces.RecipeServices
{
    public interface IReviewServices
    {
        IEnumerable<ReviewBlm> GetAll();
        void Save(ReviewBlm reviewBlm);
        void Remove(int id);
        IEnumerable<ReviewBlm> GetRecipeReviews(int recipeId);
    }
}
