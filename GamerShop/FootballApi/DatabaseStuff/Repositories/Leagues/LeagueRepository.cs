using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Base;

namespace FootballApi.DatabaseStuff.Repositories.Leagues
{
    public class LeagueRepository : BaseRepository<League>, ILeagueRepository
    {
        public LeagueRepository(FootbalLApiContext context) : base(context)
        {
        }

        public IEnumerable<ShortLeagueDataModel> Get(int count, int skipCount)
            => _dbSet
            .Skip(skipCount)
            .Take(count)
            .Select(x => new ShortLeagueDataModel
            {
                Id = x.Id,
                Country = x.Country,
                ShortName = x.ShortName
            }
            )
            .ToList();

    public IEnumerable<ShortLeagueDataModel> GetLimetedAmount(int amount)
        => _dbSet
           .Take(amount)
           .Select(x => new ShortLeagueDataModel
           {
               Id = x.Id,
               ShortName = x.ShortName
           })
           .ToList();
    }
}
