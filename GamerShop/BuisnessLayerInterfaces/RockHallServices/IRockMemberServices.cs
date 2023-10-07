using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models.RockHall;

namespace BusinessLayerInterfaces.RockHallServices
{
    public interface IRockMemberServices : IPaginatorServices<RockMemberGetBlm, RockMember>
    {
        IEnumerable<RockMemberGetBlm> GetAll();
        void Remove(int id);
        void Save(RockMemberPostBlm rockMemberBlm);
    }
}
