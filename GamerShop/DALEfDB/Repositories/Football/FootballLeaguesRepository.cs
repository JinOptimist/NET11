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

        public IEnumerable<ShortFootballLeagueDataModel> Get(int skip, int count)
        => _dbSet
            .Skip(skip)
            .Take(count)
            .Select(x => new ShortFootballLeagueDataModel
            {
                Id = x.Id,
                Country = x.Country,
                ShortName = x.ShortName
            }
            )
            .ToList();
        public IEnumerable<ShortFootballLeagueDataModel> GetLimitedAmountLigues(int count)
        => _dbSet
           .Take(count)
           .Select(x => new ShortFootballLeagueDataModel
            {
                Id = x.Id,
                ShortName = x.ShortName
            })
           .ToList();
    }
}