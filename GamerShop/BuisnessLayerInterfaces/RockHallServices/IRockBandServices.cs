using BusinessLayerInterfaces.BusinessModels.RockHall.RockBand;

namespace BusinessLayerInterfaces.RockHallServices
{
    public interface IRockBandServices
    {
        void ChooseMember(int bandId, int memberId);
        IEnumerable<RockBandGetBlm> GetAll();

        void Remove(int id);

        void Save(RockBandPostBlm rockBandBlm);
    }
}
