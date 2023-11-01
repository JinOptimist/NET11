using FootballApi.DatabaseStuff.Repositories.Clubs;
using FootballApi.DatabaseStuff.Repositories.Leagues;
using FootballApi.Service.Generator;

namespace FootballApi.DatabaseStuff
{
    public class Seed
    {
      
        public void Fill(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                FillFootbal(scope.ServiceProvider);
            }
        } 
        private void FillFootbal(IServiceProvider serviceProvider)
        {
            var footballClubRepository = serviceProvider.GetService<IClubRepository>();
            var footballLeagueRepository = serviceProvider.GetService<ILeagueRepository>();

            if (!footballClubRepository.Any()  & !footballLeagueRepository.Any())
            {
                new FootballGenerator(footballClubRepository, footballLeagueRepository).FillInfoAboutLeagues(5);
            }


        }
    }
}
