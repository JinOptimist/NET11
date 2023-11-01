using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Base;

namespace FootballApi.DatabaseStuff.Repositories.Leagues
{
    public class LeagueRepository : BaseRepository<League>, ILeagueRepository
    {
        public LeagueRepository(FootbalLApiContext context) : base(context)
        {
        }
    }
}
