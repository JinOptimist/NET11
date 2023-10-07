using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballLeagueServices : IPaginatorServices<FootballLeagueBLM,FootballLeague> 
    {
        IEnumerable<FootballLeagueBLM> GetAll();
        void Save(FootballLeagueBLM item);
        void Delete(int id);
        int Count();
        IEnumerable<ShortFootballLeagueBLM> Get(int skip, int count);
        IEnumerable<ShortFootballLeagueBLM> GetLimitedAmountLigues(int id);
    }
}
