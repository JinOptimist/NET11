using BusinessLayerInterfaces.BusinessModels.Recipe;
using BusinessLayerInterfaces.RecipeServices;
using GamerShop.Models.Recipe;
using GamerShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamerShop.Controllers
{
	public class RecipeController : Controller
	{

		private readonly IRecipeServices _recipeServices;
		private readonly IReviewServices _reviewServices;
		private readonly IPaginatorService _paginatorService;
		private readonly IAuthService _authService;

		public RecipeController(IRecipeServices recipeServices,
			IAuthService authService,
			IReviewServices reviewServices,
			IPaginatorService paginatorService)
		{
			_recipeServices = recipeServices;
			_authService = authService;
			_reviewServices = reviewServices;
			_paginatorService = paginatorService;
		}

		[Authorize]
		[HttpGet]
		public IActionResult ShowAll(int page = 1, int perPage = 3)
		{
			var viewModel = _paginatorService.GetPaginatorViewModel(_recipeServices, MapRecipeBlmToShowRecipeVM, page, perPage);
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

			return RedirectToAction("ShowFavorites");
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
		public IActionResult ShowFavorites(int page = 1, int perPage = 3)
		{
			var viewModel = _paginatorService.GetPaginatorViewModel(_recipeServices, MapRecipeBlmToFavoriteRecipeVM, page, perPage);
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
			var reviewBlm = new ReviewBlm
			{
				RecipeId = viewModel.RecipeId,
				UserId = currentUserId,
				Rating = viewModel.Rating,
				Text = viewModel.Text,
			};
			_reviewServices.Save(reviewBlm);
			return RedirectToAction("ShowAll");
		}


		private ShowRecipesViewModel MapRecipeBlmToShowRecipeVM(RecipeBlm recipeBlm)
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

		private FavoriteRecipeViewModel MapRecipeBlmToFavoriteRecipeVM(RecipeBlm recipeBlm)
			=> new FavoriteRecipeViewModel()
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
