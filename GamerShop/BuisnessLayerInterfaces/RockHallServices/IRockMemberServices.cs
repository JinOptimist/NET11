using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;

namespace BusinessLayerInterfaces.RockHallServices
{
    public interface IRockMemberServices
    {
        IEnumerable<RockMemberGetBlm> GetAll();

        void Remove(int id);

        void Save(RockMemberPostBlm rockMemberBlm);
    }
}
