using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballServices
    {
        IEnumerable<FootballClubsBlm> GetAll();
        void Save(FootballClubsBlm footClub);
        void Delete(int id);
    }
}
