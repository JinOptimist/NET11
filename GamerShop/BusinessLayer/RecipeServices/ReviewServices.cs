using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories.Recipe;

namespace BusinessLayer.RecipeServices
{
    public class ReviewServices : IReviewServices
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewServices(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<ReviewBlm> GetAll()
            => _reviewRepository
                .GetAll()
                .Select(x => new ReviewBlm()
                {
                    RecipeId = x.RecipeId,
                    UserId = x.UserId,
                    Rating = x.Rating,
                    ReviewDate = x.ReviewDate,
                    ReviewText = x.ReviewText
                });


        public void Save(ReviewBlm reviewBlm)
        {
            var dbReview = new Review()
            {
                RecipeId = reviewBlm.RecipeId,
                UserId = reviewBlm.UserId,
                Rating = reviewBlm.Rating,
                ReviewDate = reviewBlm.ReviewDate,
                ReviewText = reviewBlm.ReviewText
            };

            _reviewRepository.Save(dbReview);
        }

        public void Remove(int id)
        {
            _reviewRepository.Remove(id);
        }

        public IEnumerable<ReviewBlm> GetRecipeReviews(int recipeId)
            => _reviewRepository
                .GetRecipeReviews(recipeId)
                .Select(x => new ReviewBlm()
                {
                    RecipeId = x.RecipeId,
                    UserId = x.UserId,
                    Rating = x.Rating,
                    ReviewDate = x.ReviewDate,
                    ReviewText = x.ReviewText
                });
    }
}
