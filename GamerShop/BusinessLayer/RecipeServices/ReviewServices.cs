using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Recipe;

namespace BusinessLayer.RecipeServices
{
    public class ReviewServices : IReviewServices
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;

        public ReviewServices(IReviewRepository reviewRepository, IRecipeRepository recipeRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<ReviewBlm> GetAll()
            => _reviewRepository
                .GetAll()
                .Select(review => new ReviewBlm()
                {
                    RecipeId = review.Recipe.Id,
                    UserId = review.User.Id,
                    Rating = review.Rating,
                    Date = review.ReviewDate.ToShortDateString(),
                    Text = review.ReviewText,
                    Username = review.User.Name
                });


        public void Save(ReviewBlm reviewBlm)
        {
            var dbReview = new Review()
            {
                Recipe = _recipeRepository.Get(reviewBlm.RecipeId),
                User = _userRepository.Get(reviewBlm.UserId),
                Rating = reviewBlm.Rating,
                ReviewText = reviewBlm.Text,
                ReviewDate = DateTime.Now
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
                .Select(review => new ReviewBlm()
                {
                    RecipeId = review.Recipe.Id,
                    UserId = review.User.Id,
                    Rating = review.Rating,
                    Date = review.ReviewDate.ToShortDateString(),
                    Text = review.ReviewText,
                    Username = review.User.Name
                });
    }
}
