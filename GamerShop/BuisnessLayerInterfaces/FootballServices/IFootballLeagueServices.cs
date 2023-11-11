using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballLeagueServices : IPaginatorServices<FootballLeagueBLM> 
    {
        Task<IEnumerable<FootballLeagueBLM>> GetAll();
        Task Save(FootballLeagueBLM item);
        Task Delete(int id);
        Task<int> Count();
        Task<IEnumerable<ShortFootballLeagueBLM>> Get(int skip, int count);
        Task<IEnumerable<ShortFootballLeagueBLM>> GetLimitedAmountLigues(int id);
    }
}
