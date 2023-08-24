using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using DALInterfaces.Repositories.Recipe;
using DALEfDB.Repositories;
using DALInterfaces.Models.Recipe;
using Microsoft.Identity.Client;
using DALEfDB.Repositories.Recipe;

namespace DALEfDB
{
	public class Seed
	{
		public const int MINIMUM_USER_COUNT = 100;

		public void Fill(IServiceProvider services)
		{
			using (var scope = services.CreateScope())
			{
				FillUsers(scope.ServiceProvider);
				FillMovies(scope.ServiceProvider);
				FillRecipes(scope.ServiceProvider);
				SetFavoriteMovieForAdmin(scope.ServiceProvider);
			}
		}

		private void FillRecipes(IServiceProvider serviceProvider)
		{
			Random random = new Random();
			var recipeRepository = serviceProvider.GetService<IRecipeRepository>();
			var userRepository = serviceProvider.GetService<IUserRepository>();
			var reviewRepository = serviceProvider.GetService<IReviewRepository>();
			if (recipeRepository.Count() <= 5)
			{
				for (int i = 0; i < 10; i++)
				{
					var recipe = new Recipe
					{
						Title = "Recipe" + i,
						CookingTime = random.Next(0, 100),
						PreparationTime = random.Next(0, 60),
						Servings = random.Next(1, 6),
						CreatedByUserId = userRepository.GetAll().First().Id,
						CreatedOn = DateTime.Now,
						Cuisine = "Cuisine" + i,
						Description = "Description" + i,
						DifficultyLevel = random.Next(1, 5).ToString(),
						Instructions = "Instructions" + i,
					};
					recipeRepository.Save(recipe);
					for (int j = 0; j < random.Next(0, 5); j++)
					{
						var review = new Review()
						{
							Recipe = recipeRepository.GetAll().Last(),
							User = userRepository.GetAll().First(),
							Rating = random.Next(1, 5),
							ReviewText = "Review text" + j,
							ReviewDate = DateTime.Now
						};

						reviewRepository.Save(review);
					}
				}
			}
		}

		private void SetFavoriteMovieForAdmin(IServiceProvider serviceProvider)
		{
			var userRepository = serviceProvider.GetService<IUserRepository>();
			var user = userRepository.GetAll().First();
			if (user.FavoriteMovie == null) {
				var movieRepository = serviceProvider.GetService<IMovieRepository>();
				var movie = movieRepository.GetAll().First();
				user.FavoriteMovie = movie;
				userRepository.Update(user);
			}
		}

		private void FillMovies(IServiceProvider serviceProvider)
		{
			var movieRepository = serviceProvider.GetService<IMovieRepository>();
			if (!movieRepository.GetAll().Any())
			{
				for (int i = 0; i < 10; i++)
				{
					var movie1 = new Movie
					{
						Title = $"Die Hard {i}",
						CreatedDate = new DateTime(2020, 12, 13),
					};
					movieRepository.Save(movie1);
				}
			}
		}

		private void FillUsers(IServiceProvider provider)
		{
			var userRepository = provider.GetService<IUserRepository>();
			if (userRepository.Count() <= 0)
			{
				var admin = new User
				{
					Name = "Admin",
					Password = "123",
					Birthday = DateTime.Now,
				};
				userRepository.Save(admin);

				var user = new User
				{
					Name = "User",
					Password = "123",
					Birthday = DateTime.Now,
				};
				userRepository.Save(user);
			}

			if (userRepository.Count() < MINIMUM_USER_COUNT)
			{
				for (int i = 0; i < MINIMUM_USER_COUNT; i++)
				{
					var user = new User
					{
						Name = $"Bot{i}",
						Password = "123",
						Birthday = DateTime.Now,
					};
					userRepository.Save(user);
				}
			}
		}
	}
}
