using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Recipe;

namespace DALEfDB.Repositories.Recipe
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(WebContext context) : base(context)
        {
        }

        public IEnumerable<Review> GetRecipeReviews(int recipeId)
        {
            return _dbSet.Where(review => review.Recipe.Id == recipeId).ToList();
        }
    }
}
