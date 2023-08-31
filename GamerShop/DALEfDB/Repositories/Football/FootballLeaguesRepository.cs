using DALInterfaces.Models.Football;
using DALInterfaces.Repositories.Football;

namespace DALEfDB.Repositories.Football
{
    public class FootballLeaguesRepository : BaseRepository<FootballLeague>, IFootballLeagueRepository
    {
        public FootballLeaguesRepository(WebContext context) : base(context) { }


    }
}