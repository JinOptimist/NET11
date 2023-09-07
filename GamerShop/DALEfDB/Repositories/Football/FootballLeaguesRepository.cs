using DALInterfaces.DataModels.Football;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories.Football;

namespace DALEfDB.Repositories.Football
{
    public class FootballLeaguesRepository : BaseRepository<FootballLeague>, IFootballLeagueRepository
    {
        public FootballLeaguesRepository(WebContext context) : base(context) { }

        public IEnumerable<ShortFootballLeagueDataModel> GetAllFromCountry(string country)
        => _dbSet
           .Where(x => x.Country == country)
           .Select(x => new ShortFootballLeagueDataModel
            {
                Id = x.Id,
                Country = x.Country,
                ShortName = x.ShortName
            })
           .ToList();

    }
}