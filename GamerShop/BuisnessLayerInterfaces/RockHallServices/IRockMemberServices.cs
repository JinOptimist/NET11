using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.RockHallServices
{
    public interface IRockMemberServices : IPaginatorServices<RockMemberGetBlm>
    {
        IEnumerable<RockMemberGetBlm> GetAll();
        void Remove(int id);
        void Save(RockMemberPostBlm rockMemberBlm);
    }
}
