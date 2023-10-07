using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.RecipeServices;
using DALInterfaces.Models.Recipe;
using GamerShop.Hubs.Recipe;
using GamerShop.Models.Recipe;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GamerShop.Controllers
{
	public class RecipeController : Controller
	{

		private readonly IRecipeServices _recipeServices;
		private readonly IReviewServices _reviewServices;
        private readonly IPaginatorService _paginatorService;
        private readonly IAuthService _authService;
        private readonly IHubContext<ReviewHub> _commentHubContext;

		public RecipeController(IRecipeServices recipeServices, 
			IAuthService authService, 
			IReviewServices reviewServices, 
			IPaginatorService paginatorService,
			IHubContext<ReviewHub> commentHubContext)
        {
            _recipeServices = recipeServices;
            _authService = authService;
            _reviewServices = reviewServices;
            _paginatorService = paginatorService;
            _commentHubContext = commentHubContext;
        }

        [Authorize]
		[HttpGet]
		public IActionResult ShowAll(int page = 1, int perPage = 3)
		{
			var viewModel = _paginatorService.GetPaginatorViewModel(_recipeServices, Map, page, perPage);
			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public IActionResult ShowRecipe(int recipeId)
		{
			var currentUserId = _authService.GetCurrentUser().Id;
			var recipeBlm = _recipeServices.GetRecipeById(recipeId);
			var viewModel = new ShowRecipeViewModel()
			{
				Id = recipeBlm.Id,
				Title = recipeBlm.Title,
				Description = recipeBlm.Title,
				Instructions = recipeBlm.Instructions,
				CookingTime = recipeBlm.CookingTime,
				PreparationTime = recipeBlm.PreparationTime,
				Servings = recipeBlm.Servings,
				DifficultyLevel = recipeBlm.DifficultyLevel,
				Cuisine = recipeBlm.Cuisine,
				IsFavorite = _recipeServices.GetFavoriteByUser(currentUserId).Any(blm => blm.Id == recipeBlm.Id),
				Reviews = _reviewServices.GetRecipeReviews(recipeBlm.Id).Select(reviewBlm => new DisplayReviewViewModel
				{
					Rating = reviewBlm.Rating,
					Text = reviewBlm.Text,
					Date = reviewBlm.Date,
					RecipeId = reviewBlm.RecipeId,
					Username = reviewBlm.Username
				}).ToList()
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(AddRecipeViewModel addRecipeViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var currentUserId = _authService.GetCurrentUser().Id;
			var recipeBlm = new RecipeBlm()
			{
				Title = addRecipeViewModel.Title,
				Description = addRecipeViewModel.Title,
				Instructions = addRecipeViewModel.Instructions,
				CookingTime = addRecipeViewModel.CookingTime,
				PreparationTime = addRecipeViewModel.PreparationTime,
				Servings = addRecipeViewModel.Servings,
				DifficultyLevel = addRecipeViewModel.DifficultyLevel,
				Cuisine = addRecipeViewModel.Cuisine,
				CreatedByUserId = currentUserId,
				CreatedOn = DateTime.Now
			};

			_recipeServices.Save(recipeBlm);
			return RedirectToAction("ShowAll");
		}

		public IActionResult Remove(int id)
		{
			_recipeServices.Remove(id);
			return RedirectToAction("ShowAll");
		}

		public IActionResult RemoveFavorite(int recipeId)
		{
			var currentUserId = _authService.GetCurrentUser().Id;
			_recipeServices.RemoveFavorite(new FavoriteRecipeBlm()
			{
				RecipeId = recipeId,
				UserId = currentUserId
			});

			return RedirectToAction("Favorites");
		}

		public IActionResult AddFavorite(int recipeId)
		{
			var currentUserId = _authService.GetCurrentUser().Id;
			_recipeServices.AddFavorite(new FavoriteRecipeBlm()
			{
				RecipeId = recipeId,
				UserId = currentUserId
			});
			return RedirectToAction("ShowAll");
		}

		[Authorize]
		[HttpGet]
		public IActionResult Favorites()
		{
			var currentUserId = _authService.GetCurrentUser().Id;
			var viewModel = _recipeServices
			.GetFavoriteByUser(currentUserId)
			.Select(x => new FavoriteRecipeViewModel()
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Title,
				Instructions = x.Instructions,
				CookingTime = x.CookingTime,
				PreparationTime = x.PreparationTime,
				Servings = x.Servings,
				DifficultyLevel = x.DifficultyLevel,
				Cuisine = x.Cuisine
			}).ToList();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SubmitReview(ReviewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ShowAll");
            }
            var currentUserId = _authService.GetCurrentUser().Id;
			var review = new ReviewBlm
			{
				RecipeId = viewModel.RecipeId,
				UserId = currentUserId,
				Rating = viewModel.Rating,
				Text = viewModel.Text,
            };
            _reviewServices.Save(review);
			
            _commentHubContext.Clients.All.SendAsync("NewReviewAdded", review.Username, review.Text, review.Rating, review.Date);

            return RedirectToAction("ShowRecipe", new { recipeId = viewModel.RecipeId });
        }


		private ShowRecipesViewModel Map(RecipeBlm recipeBlm)
		{
            var currentUserId = _authService.GetCurrentUser().Id;
            return new ShowRecipesViewModel
			{
				Id = recipeBlm.Id,
				Title = recipeBlm.Title,
				Description = recipeBlm.Title,
				CookingTime = recipeBlm.CookingTime,
				PreparationTime = recipeBlm.PreparationTime,
				Servings = recipeBlm.Servings,
				DifficultyLevel = recipeBlm.DifficultyLevel,
				Cuisine = recipeBlm.Cuisine,
				IsFavorite = _recipeServices.GetFavoriteByUser(currentUserId).Any(blm => blm.Id == recipeBlm.Id),
				Reviews = _reviewServices.GetRecipeReviews(recipeBlm.Id).Select(reviewBlm => new DisplayReviewViewModel
				{
					Rating = reviewBlm.Rating,
					Text = reviewBlm.Text,
					Date = reviewBlm.Date,
					RecipeId = reviewBlm.RecipeId,
					Username = reviewBlm.Username
				}).ToList()
			};
        }
	}
}
