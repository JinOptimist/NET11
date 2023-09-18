using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballClubService : IPaginatorServices<FootballClubBlm> 
    {
        IEnumerable<FootballClubBlm> GetAll();
        void Save(FootballClubBlm item);
        void Delete(int id);

    }
}
