using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

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

				SetFavoriteMovieForAdmin(scope.ServiceProvider);
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
