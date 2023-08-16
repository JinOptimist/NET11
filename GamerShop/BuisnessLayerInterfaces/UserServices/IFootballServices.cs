using BusinessLayerInterfaces.BusinessModels;
using System.Xml.Linq;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IFootballServices
    {
        IEnumerable<FootballClubsBlm> GetAll();
        void Save(FootballClubsBlm footClub);
        void Delete(int id);
    }
}
