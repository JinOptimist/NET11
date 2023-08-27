using DALInterfaces.Models;
using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.RockHall;
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
                FillRockMembers(scope.ServiceProvider);
                FillRockBands(scope.ServiceProvider);

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

        private void FillRockBands(IServiceProvider provider)
        {
            var rockBandRepository = provider.GetService<IRockBandRepository>();
            if (!rockBandRepository.GetAll().Any())
            {
                var theOffspring = new RockBand
                {
                    FullName = "The Offspring",
                    CreatorId = 1
                };
                rockBandRepository.Save(theOffspring);

                for (int i = 0; i < 10; i++)
                {
                    var blink182 = new RockBand
                    {
                        FullName = $"Blink-18{i}",
                        CreatorId = 1
                    };
                    rockBandRepository.Save(blink182);
                }
            }
        }

        private void FillRockMembers(IServiceProvider provider)
        {
            var rockMemberRepository = provider.GetService<IRockMemberRepository>();
            if (rockMemberRepository.Count() <= 0)
            {
                var paulMcCartney = new RockMember
                {
                    FullName = "Paul McCartney",
                    EntryYear = 1996,
                    YearOfBirth = 1996,
                    Genre = "Pop Rock",
                    CreatorId = 1
                };
                rockMemberRepository.Save(paulMcCartney);

                var johnLenon = new RockMember
                {
                    FullName = "John Lenon",
                    EntryYear = 1996,
                    YearOfBirth = 1996,
                    Genre = "Indi Rock",
                    CreatorId = 1
                };
                rockMemberRepository.Save(johnLenon);
            }

            if (rockMemberRepository.Count() < MINIMUM_USER_COUNT)
            {
                for (int i = 0; i < MINIMUM_USER_COUNT; i++)
                {
                    var slash = new RockMember
                    {
                        FullName = $"Slash {i}",
                        EntryYear = 1996,
                        YearOfBirth = 1996,
                        Genre = "Indi Rock",
                        CreatorId = 1
                    };
                    rockMemberRepository.Save(slash);
                }
            }
        }
    }
}
