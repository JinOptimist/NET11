using DALInterfaces.DataModels.Football;
using DALInterfaces.Models.Football;

namespace DALInterfaces.Repositories.Football
{
    public interface IFootballLeagueRepository : IBaseRepository<FootballLeague>
    {
        IEnumerable<ShortFootballLeagueDataModel> GetAllFromCountry(string country);
       
    }
}


